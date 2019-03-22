namespace BankAccountNumberRegistry.Api.Organisation
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Be.Vlaanderen.Basisregisters.Api;
    using Be.Vlaanderen.Basisregisters.Api.Exceptions;
    using Be.Vlaanderen.Basisregisters.Api.Search;
    using Be.Vlaanderen.Basisregisters.Api.Search.Filtering;
    using Be.Vlaanderen.Basisregisters.Api.Search.Pagination;
    using Be.Vlaanderen.Basisregisters.Api.Search.Sorting;
    using Be.Vlaanderen.Basisregisters.CommandHandling;
    using Infrastructure.Responses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json.Converters;
    using Projections.Api;
    using Query;
    using Requests;
    using Responses;
    using Swashbuckle.AspNetCore.Filters;

    public partial class OrganisationController
    {
        /// <summary>
        /// Voeg een bankrekeningnummer toe aan een organisatie.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="commandId">Optionele unieke id voor het verzoek.</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="202">Als het verzoek aanvaard is.</response>
        /// <response code="400">Als het verzoek ongeldige data bevat.</response>
        /// <response code="500">Als er een interne fout is opgetreden.</response>
        /// <returns></returns>
        [HttpPost("{ovoNumber}/bankaccountnumbers")]
        [ProducesResponseType(typeof(void), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(BasicApiValidationProblem), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BasicApiProblem), StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(AddOrganisationBankAccountRequest), typeof(AddOrganisationBankAccountRequestExample))]
        [SwaggerResponseExample(StatusCodes.Status202Accepted, typeof(EmptyResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidationErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(InternalServerErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        public async Task<IActionResult> RegisterOrganisation(
            [FromServices] ICommandHandlerResolver bus,
            [FromCommandId] Guid commandId,
            [FromBody] AddOrganisationBankAccountRequest request,
            CancellationToken cancellationToken = default)
        {
            await new AddOrganisationBankAccountRequestValidator()
                .ValidateAndThrowAsync(request, cancellationToken: cancellationToken);

            var command = AddOrganisationBankAccountRequestMapping.Map(request);

            return Accepted(
                $"/v1/organisations/{command.OvoNumber}/bankaccountnumbers/{command}", // TODO: Add correct bank id
                await bus.Dispatch(
                    commandId,
                    command,
                    GetMetadata(),
                    cancellationToken));
        }

        /// <summary>
        /// Vraag een lijst met bankrekeningnummers van een organisatie op.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ovoNumber">OVO nummer van de organisatie.</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Als de opvraging van een lijst met bankrekeningnummers van een organisatie gelukt is.</response>
        /// <response code="500">Als er een interne fout is opgetreden.</response>
        /// <returns></returns>
        [HttpGet("{ovoNumber}/bankaccountnumbers")]
        [ProducesResponseType(typeof(OrganisationBankAccountNumberListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BasicApiProblem), StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrganisationBankAccountNumberListResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(InternalServerErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        public async Task<IActionResult> ListOrganisationBankAccountNumbers(
            [FromServices] ApiProjectionsContext context,
            [FromRoute] string ovoNumber,
            CancellationToken cancellationToken = default)
        {
            var filtering = Request.ExtractFilteringRequest<OrganisationBankAccountNumberFilter>();
            var sorting = Request.ExtractSortingRequest();
            var pagination = Request.ExtractPaginationRequest();

            var pagedOrganisationBankAccountNumbers = new OrganisationBankAccountNumberListQuery(context)
                .Fetch(filtering, sorting, pagination);

            Response.AddPagedQueryResultHeaders(pagedOrganisationBankAccountNumbers);

            return Ok(
                new OrganisationBankAccountNumberListResponse
                {
                    OrganisationBankAccountNumbers = await pagedOrganisationBankAccountNumbers
                        .Items
                        .Select(x => new OrganisationBankAccountNumberListItemResponse(x))
                        .ToListAsync(cancellationToken)
                });
        }
    }
}
