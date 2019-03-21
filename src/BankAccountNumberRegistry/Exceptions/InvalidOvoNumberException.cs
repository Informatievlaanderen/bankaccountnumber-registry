namespace BankAccountNumberRegistry.Exceptions
{
    public class InvalidOvoNumberException : BankAccountNumberRegistryException
    {
        public InvalidOvoNumberException(string message) : base(message) { }
    }

    public class EmptyOvoNumberException : InvalidOvoNumberException
    {
        public EmptyOvoNumberException() : base("OVO nummer kan niet leeg zijn.") { }
    }

    public class OvoNumberTooLongException : InvalidOvoNumberException
    {
        public OvoNumberTooLongException() : base($"OVO nummer kan niet langer zijn dan {OvoNumber.MaxLength} tekens.") { }
    }
}
