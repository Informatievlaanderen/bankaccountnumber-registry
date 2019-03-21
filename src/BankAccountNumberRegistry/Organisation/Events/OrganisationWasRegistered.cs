namespace BankAccountNumberRegistry.Organisation.Events
{
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Newtonsoft.Json;

    [EventName("OrganisationWasRegistered")]
    [EventDescription("The organisation was registered.")]
    public class OrganisationWasRegistered
    {
        public string OvoNumber { get; }

        public OrganisationWasRegistered(
            OvoNumber ovoNumber)
        {
            OvoNumber = ovoNumber;
        }

        [JsonConstructor]
        private OrganisationWasRegistered(
            string ovoNumber)
            : this(new OvoNumber(ovoNumber)) { }
    }
}
