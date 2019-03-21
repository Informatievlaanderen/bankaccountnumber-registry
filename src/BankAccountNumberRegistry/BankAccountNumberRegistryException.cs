namespace BankAccountNumberRegistry
{
    using System;
    using Be.Vlaanderen.Basisregisters.AggregateSource;

    public abstract class BankAccountNumberRegistryException : DomainException
    {
        protected BankAccountNumberRegistryException() { }

        protected BankAccountNumberRegistryException(string message) : base(message) { }

        protected BankAccountNumberRegistryException(string message, Exception inner) : base(message, inner) { }
    }
}
