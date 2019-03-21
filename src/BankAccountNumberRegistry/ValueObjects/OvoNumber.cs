namespace BankAccountNumberRegistry
{
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using Newtonsoft.Json;

    public class OvoNumber : StringValueObject<OvoNumber>
    {
        public OvoNumber([JsonProperty("value")] string ovoNumber) : base(ovoNumber?.Trim()) { }
    }
}
