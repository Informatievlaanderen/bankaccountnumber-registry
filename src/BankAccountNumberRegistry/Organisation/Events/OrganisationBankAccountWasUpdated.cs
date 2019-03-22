namespace BankAccountNumberRegistry.Organisation.Events
{
    using System;
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Newtonsoft.Json;

    [EventName("OrganisationBankAccountWasUpdated")]
    [EventDescription("A bank account of an organisation was updated.")]
    public class OrganisationBankAccountWasUpdated
    {
        public string OvoNumber { get; }

        public Guid OrganisationBankAccountId { get; }

        public string BankAccountNumber { get; }
        public string PreviousBankAccountNumber { get; }

        public string Bic { get; }
        public string PreviousBic { get; }

        public bool IsIban { get; }
        public bool WasPreviouslyIban { get; }

        public bool IsBic { get; }
        public bool WasPreviouslyBic { get; }

        public DateTime? ValidFrom { get; }
        public DateTime? PreviouslyValidFrom { get; }

        public DateTime? ValidTo { get; }
        public DateTime? PreviouslyValidTo { get; }

        public OrganisationBankAccountWasUpdated(
            OvoNumber ovoNumber,
            Guid organisationBankAccountId,
            string bankAccountNumber,
            bool isIban,
            string bic,
            bool isBic,

            DateTime? validFrom,
            DateTime? validTo,
            string previousBankAccountNumber,
            bool wasPreviouslyIban,
            string previousBic,
            bool wasPreviouslyBic,
            DateTime? previouslyValidFrom,
            DateTime? previouslyValidTo)
        {
            OvoNumber = ovoNumber;
            OrganisationBankAccountId = organisationBankAccountId;
            BankAccountNumber = bankAccountNumber;
            IsIban = isIban;
            Bic = bic;
            IsBic = isBic;
            ValidFrom = validFrom;
            ValidTo = validTo;

            PreviousBankAccountNumber = previousBankAccountNumber;
            WasPreviouslyIban = wasPreviouslyIban;
            PreviousBic = previousBic;
            WasPreviouslyBic = wasPreviouslyBic;
            PreviouslyValidFrom = previouslyValidFrom;
            PreviouslyValidTo = previouslyValidTo;
        }

        [JsonConstructor]
        public OrganisationBankAccountWasUpdated(
            string ovoNumber,
            Guid organisationBankAccountId,
            string bankAccountNumber,
            bool isIban,
            string bic,
            bool isBic,

            DateTime? validFrom,
            DateTime? validTo,
            string previousBankAccountNumber,
            bool wasPreviouslyIban,
            string previousBic,
            bool wasPreviouslyBic,
            DateTime? previouslyValidFrom,
            DateTime? previouslyValidTo)
            : this(
                new OvoNumber(ovoNumber),
                organisationBankAccountId,
                bankAccountNumber,
                isIban,
                bic,
                isBic,
                validFrom,
                validTo,
                previousBankAccountNumber,
                wasPreviouslyIban,
                previousBic,
                wasPreviouslyBic,
                previouslyValidFrom,
                previouslyValidTo) { }
    }
}
