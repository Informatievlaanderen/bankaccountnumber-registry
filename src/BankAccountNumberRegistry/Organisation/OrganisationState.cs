namespace BankAccountNumberRegistry.Organisation
{
    using System.Collections.Generic;
    using System.Linq;
    using BankAccount;
    using BankAccount.Events;
    using Events;

    public partial class Organisation
    {
        private OvoNumber _ovoNumber;

        private readonly List<BankAccount> _bankAccounts = new List<BankAccount>();

        private Organisation()
        {
            Register<OrganisationWasRegistered>(When);
            Register<OrganisationBankAccountWasAdded>(When);
            Register<BankAccountWasLinkedToPublicService>(When);
        }

        private void When(OrganisationWasRegistered @event)
        {
            _ovoNumber = new OvoNumber(@event.OvoNumber);
        }

        private void When(OrganisationBankAccountWasAdded @event)
        {
            //_bankAccounts.Add(
            //    new BankAccountNumber(ApplyChange));
        }

        private void When(BankAccountWasLinkedToPublicService @event)
        {
            //var bankAccount = _bankAccounts.First(x => x.)
            //bankAccount.Route(@event);
        }
    }
}
