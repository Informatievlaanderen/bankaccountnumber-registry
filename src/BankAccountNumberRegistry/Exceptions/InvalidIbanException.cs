namespace BankAccountNumberRegistry.Exceptions
{
    using System;

    public class InvalidIbanException : BankAccountNumberRegistryException
    {
        public InvalidIbanException(Exception ex) : base(ex.Message, ex) { }
    }
}
