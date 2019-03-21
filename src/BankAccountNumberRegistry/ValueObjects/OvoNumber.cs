namespace BankAccountNumberRegistry
{
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using Exceptions;
    using Newtonsoft.Json;

    public class OvoNumber : StringValueObject<OvoNumber>
    {
        public static int MaxLength = "OVO003347".Length;

        public OvoNumber([JsonProperty("value")] string ovoNumber) : base(ovoNumber?.Trim())
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new EmptyOvoNumberException();

            if (Value.Length > MaxLength)
                throw new OvoNumberTooLongException();
        }
    }
}
