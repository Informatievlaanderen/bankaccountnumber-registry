namespace BankAccountNumberRegistry.Organisation
{
    using Events;

    public partial class Organisation
    {
        private OvoNumber _ovoNumber;

        private Organisation()
        {
            Register<OrganisationWasRegistered>(When);
        }

        private void When(OrganisationWasRegistered @event)
        {
            _ovoNumber = new OvoNumber(@event.OvoNumber);
        }
    }
}
