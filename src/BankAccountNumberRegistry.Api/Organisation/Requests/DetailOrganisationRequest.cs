namespace BankAccountNumberRegistry.Api.Organisation.Requests
{
    using System.ComponentModel.DataAnnotations;
    using FluentValidation;

    public class DetailOrganisationRequest
    {
        /// <summary>OVO nummer van de organisatie.</summary>
        [Required]
        [Display(Name = "OVO Nummer")]
        public string OvoNumber { get; set; }
    }

    public class DetailOrganisationRequestValidator : AbstractValidator<DetailOrganisationRequest>
    {
        public DetailOrganisationRequestValidator()
        {
            RuleFor(x => x.OvoNumber)
                .Required()
                .ValidOvoNumber()
                .MaxLength(OvoNumber.MaxLength);
        }
    }
}
