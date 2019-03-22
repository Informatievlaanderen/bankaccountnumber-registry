namespace BankAccountNumberRegistry.Organisation
{
    using System.Collections.Generic;
    using BankAccountNumber;
    using Events;

    public partial class Organisation
    {
        private OvoNumber _ovoNumber;

        private readonly List<BankAccountNumber> _bankAccountNumbers = new List<BankAccountNumber>();

        private Organisation()
        {
            Register<OrganisationWasRegistered>(When);
            Register<OrganisationBankAccountWasAdded>(When);
        }

        private void When(OrganisationWasRegistered @event)
        {
            _ovoNumber = new OvoNumber(@event.OvoNumber);
        }

        private void When(OrganisationBankAccountWasAdded @event)
        {
            //_bankAccountNumbers.Add(
            //    new BankAccountNumber());
        }
    }
}
