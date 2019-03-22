namespace BankAccountNumberRegistry.BankAccountNumber
{
    using System;
    using System.Text.RegularExpressions;
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using Exceptions;
    using IbanBic;

    public class BankAccountNumber : Entity
    {
        public string Number { get; }
        public bool IsValidIban { get; }

        public BankAccountNumber(
            Action<object> applyChange,
            string bankAccountNumber,
            bool isValidIban) : base(applyChange)
        {
            IsValidIban = isValidIban;
            Number = isValidIban ? CleanBankAccountNumber(bankAccountNumber) : bankAccountNumber;

            if (isValidIban)
                ValidateIbanOrThrow();
        }

        private static string CleanBankAccountNumber(string bankAccountNumber)
            => Regex.Replace(bankAccountNumber, @"[^0-9a-zA-Z]", string.Empty);

        private void ValidateIbanOrThrow()
        {
            try
            {
                IbanUtils.Validate(Number);
            }
            catch (Exception ex)
            {
                throw new InvalidIbanException(ex);
            }
        }
    }
}
