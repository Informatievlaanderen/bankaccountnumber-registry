namespace BankAccountNumberRegistry.Api.Organisation.Requests
{
    using System.ComponentModel.DataAnnotations;
    using BankAccountNumberRegistry.Organisation.Commands;
    using FluentValidation;
    using Swashbuckle.AspNetCore.Filters;

    public class RegisterOrganisationRequest
    {
        /// <summary>OVO Nummer van de te registreren organiatie.</summary>
        [Required]
        [Display(Name = "OVO Nummer")]
        public string OvoNumber { get; set; }
    }

    public class RegisterOrganisationRequestValidator : AbstractValidator<RegisterOrganisationRequest>
    {
        public RegisterOrganisationRequestValidator()
        {
            RuleFor(x => x.OvoNumber)
                .Required()
                .ValidOvoNumber()
                .MaxLength(OvoNumber.MaxLength);
        }
    }

    public class RegisterOrganisationRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new RegisterOrganisationRequest
            {
                OvoNumber = "OVO003347"
            };
        }
    }

    public static class RegisterOrganisationRequestMapping
    {
        public static RegisterOrganisation Map(RegisterOrganisationRequest message)
        {
            return new RegisterOrganisation(
                new OvoNumber(message.OvoNumber));
        }
    }
}
