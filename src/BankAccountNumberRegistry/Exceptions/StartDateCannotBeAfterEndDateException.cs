namespace BankAccountNumberRegistry.Exceptions
{
    public class StartDateCannotBeAfterEndDateException : BankAccountNumberRegistryException
    {
        public StartDateCannotBeAfterEndDateException() : base("De startdatum mag niet na de einddatum vallen.") { }
    }
}
