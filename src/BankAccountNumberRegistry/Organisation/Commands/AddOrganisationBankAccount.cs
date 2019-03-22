namespace BankAccountNumberRegistry.Organisation.Commands
{
    using System;

    public class AddOrganisationBankAccount
    {
        public OvoNumber OvoNumber { get; }

        public Guid OrganisationBankAccountId { get; }
        public string BankAccountNumber { get; }
        public bool IsIban { get; }
        public string Bic { get; }
        public bool IsBic { get; }
        public ValidFrom ValidFrom { get; }
        public ValidTo ValidTo { get; }

        public AddOrganisationBankAccount(
            Guid organisationBankAccountId,
            OvoNumber ovoNumber,
            string bankAccountNumber,
            bool isIban,
            string bic,
            bool isBic,
            ValidFrom validFrom,
            ValidTo validTo)
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
    }
}
