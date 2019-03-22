namespace BankAccountNumberRegistry.Organisation.Events
{
    using System;
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Newtonsoft.Json;

    [EventName("OrganisationBankAccountWasAdded")]
    [EventDescription("A bank account was added to the organisation.")]
    public class OrganisationBankAccountWasAdded
    {
        public string OvoNumber { get; }

        public Guid OrganisationBankAccountId { get; }
        public string BankAccountNumber { get; }
        public bool IsIban { get; }
        public string Bic { get; }
        public bool IsBic { get; }
        public DateTime? ValidFrom { get; }
        public DateTime? ValidTo { get; }

        public OrganisationBankAccountWasAdded(
            OvoNumber ovoNumber,
            Guid organisationBankAccountId,
            string bankAccountNumber,
            bool isIban,
            string bic,
            bool isBic,
            DateTime? validFrom,
            DateTime? validTo)
        {
            OvoNumber = ovoNumber;
            OrganisationBankAccountId = organisationBankAccountId;
            BankAccountNumber = bankAccountNumber;
            IsIban = isIban;
            Bic = bic;
            IsBic = isBic;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        [JsonConstructor]
        public OrganisationBankAccountWasAdded(
            string ovoNumber,
            Guid organisationBankAccountId,
            string bankAccountNumber,
            bool isIban,
            string bic,
            bool isBic,
            DateTime? validFrom,
            DateTime? validTo)
            : this(
                new OvoNumber(ovoNumber),
                organisationBankAccountId,
                bankAccountNumber,
                isIban,
                bic,
                isBic,
                validFrom,
                validTo) { }
    }
}
