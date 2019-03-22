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
    using Infrastructure;
    using Infrastructure.Responses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json.Converters;
    using Projections.Api;
    using Projections.Api.OrganisationDetail;
    using Query;
    using Requests;
    using Responses;
    using Swashbuckle.AspNetCore.Filters;

    [ApiVersion("1.0")]
    [AdvertiseApiVersions("1.0")]
    [ApiRoute("organisations")]
    [ApiExplorerSettings(GroupName = "Organisaties")]
    public partial class OrganisationController : BankAccountNumberRegistryController
    {
        /// <summary>
        /// Registreer een organisatie.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="commandId">Optionele unieke id voor het verzoek.</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="202">Als het verzoek aanvaard is.</response>
        /// <response code="400">Als het verzoek ongeldige data bevat.</response>
        /// <response code="500">Als er een interne fout is opgetreden.</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(BasicApiValidationProblem), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BasicApiProblem), StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(RegisterOrganisationRequest), typeof(RegisterOrganisationRequestExample))]
        [SwaggerResponseExample(StatusCodes.Status202Accepted, typeof(EmptyResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidationErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(InternalServerErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        public async Task<IActionResult> RegisterOrganisation(
            [FromServices] ICommandHandlerResolver bus,
            [FromCommandId] Guid commandId,
            [FromBody] RegisterOrganisationRequest request,
            CancellationToken cancellationToken = default)
        {
            await new RegisterOrganisationRequestValidator()
                .ValidateAndThrowAsync(request, cancellationToken: cancellationToken);

            var command = RegisterOrganisationRequestMapping.Map(request);

            return Accepted(
                $"/v1/organisations/{command.OvoNumber}",
                await bus.Dispatch(
                    commandId,
                    command,
                    GetMetadata(),
                    cancellationToken));
        }

        /// <summary>
        /// Vraag een lijst met organisaties op.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Als de opvraging van een lijst met organisaties gelukt is.</response>
        /// <response code="500">Als er een interne fout is opgetreden.</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(OrganisationListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BasicApiProblem), StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrganisationListResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(InternalServerErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        public async Task<IActionResult> ListOrganisations(
            [FromServices] ApiProjectionsContext context,
            CancellationToken cancellationToken = default)
        {
            var filtering = Request.ExtractFilteringRequest<OrganisationFilter>();
            var sorting = Request.ExtractSortingRequest();
            var pagination = Request.ExtractPaginationRequest();

            var pagedOrganisations = new OrganisationListQuery(context)
                .Fetch(filtering, sorting, pagination);

            Response.AddPagedQueryResultHeaders(pagedOrganisations);

            return Ok(
                new OrganisationListResponse
                {
                    Organisations = await pagedOrganisations
                        .Items
                        .Select(x => new OrganisationListItemResponse(x))
                        .ToListAsync(cancellationToken)
                });
        }

        /// <summary>
        /// Vraag een organisatie op.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ovoNumber">OVO nummer van de organisatie.</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Als de organisatie gevonden is.</response>
        /// <response code="400">Als het verzoek ongeldige data bevat.</response>
        /// <response code="404">Als de organisatie niet gevonden kan worden.</response>
        /// <response code="500">Als er een interne fout is opgetreden.</response>
        /// <returns></returns>
        [HttpGet("{ovoNumber}")]
        [ProducesResponseType(typeof(OrganisationDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BasicApiValidationProblem), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BasicApiProblem), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BasicApiProblem), StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrganisationResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidationErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(OrganisationNotFoundResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(InternalServerErrorResponseExamples), jsonConverter: typeof(StringEnumConverter))]
        public async Task<IActionResult> DetailDomain(
            [FromServices] ApiProjectionsContext context,
            [FromRoute] string ovoNumber,
            CancellationToken cancellationToken = default)
        {
            var request = new DetailOrganisationRequest
            {
                OvoNumber = ovoNumber,
            };

            await new DetailOrganisationRequestValidator()
                .ValidateAndThrowAsync(request, cancellationToken: cancellationToken);

            var organisation = await FindOrganisationAsync(context, ovoNumber, cancellationToken);

            return Ok(
                new OrganisationDetailResponse(organisation));
        }

        private static async Task<OrganisationDetail> FindOrganisationAsync(
            ApiProjectionsContext context,
            string ovoNumber,
            CancellationToken cancellationToken)
        {
            var organisation = await context
                .OrganisationDetails
                .FindAsync(new object[] { ovoNumber }, cancellationToken);

            if (organisation == null)
                throw new ApiException(OrganisationNotFoundResponseExamples.Message, StatusCodes.Status404NotFound);

            return organisation;
        }
    }
}
