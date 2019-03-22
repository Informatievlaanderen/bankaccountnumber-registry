namespace BankAccountNumberRegistry.Api.Organisation.Responses
{
    using Be.Vlaanderen.Basisregisters.Api.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Filters;

    public class OrganisationNotFoundResponseExamples : IExamplesProvider
    {
        public static string Message = "Organisatie niet gevonden.";

        public object GetExamples()
            => new BasicApiProblem
            {
                HttpStatus = StatusCodes.Status404NotFound,
                Title = BasicApiProblem.DefaultTitle,
                Detail = Message,
                ProblemInstanceUri = BasicApiProblem.GetProblemNumber()
            };
    }
}
