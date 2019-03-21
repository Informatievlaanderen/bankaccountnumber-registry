namespace BankAccountNumberRegistry
{
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using Newtonsoft.Json;

    public class OvoNumber : StringValueObject<OvoNumber>
    {
        public static int MaxLength = "OVO003347".Length;

        public OvoNumber([JsonProperty("value")] string ovoNumber) : base(ovoNumber?.Trim()) { }
    }
}
