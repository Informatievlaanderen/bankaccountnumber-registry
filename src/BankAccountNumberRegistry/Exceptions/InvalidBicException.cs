namespace BankAccountNumberRegistry.Exceptions
{
    using System;

    public class InvalidBicException : BankAccountNumberRegistryException
    {
        public InvalidBicException(Exception ex) : base(ex.Message, ex) { }
    }
}
