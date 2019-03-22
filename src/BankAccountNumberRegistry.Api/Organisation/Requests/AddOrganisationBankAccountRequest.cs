namespace BankAccountNumberRegistry.Api.Organisation.Requests
{
    using System.ComponentModel.DataAnnotations;
    using BankAccountNumberRegistry.Organisation.Commands;
    using FluentValidation;
    using Swashbuckle.AspNetCore.Filters;

    public class AddOrganisationBankAccountRequest
    {
        /// <summary>OVO Nummer van de organisatie om een bankrekeningnummer aan toe te voegen.</summary>
        [Required]
        [Display(Name = "OVO Nummer")]
        internal string OvoNumber { get; set; }
    }

    public class AddOrganisationBankAccountRequestValidator : AbstractValidator<AddOrganisationBankAccountRequest>
    {
        public AddOrganisationBankAccountRequestValidator()
        {
            RuleFor(x => x.OvoNumber)
                .Required()
                .ValidOvoNumber()
                .MaxLength(OvoNumber.MaxLength);
        }
    }

    public class AddOrganisationBankAccountRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new AddOrganisationBankAccountRequest
            {
                OvoNumber = "OVO003347"
            };
        }
    }

    public static class AddOrganisationBankAccountRequestMapping
    {
        public static AddOrganisationBankAccount Map(AddOrganisationBankAccountRequest message)
        {
            return null;
            //return new AddOrganisationBankAccount(
            //    new OvoNumber(message.OvoNumber),
            //    ...);
        }
    }
}
