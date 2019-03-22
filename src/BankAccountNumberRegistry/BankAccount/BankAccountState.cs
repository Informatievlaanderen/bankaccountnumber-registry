namespace BankAccountNumberRegistry.BankAccount
{
    using System;
    using Events;

    public partial class BankAccount
    {
        private BankAccountNumber _number;
        private BankAccountBic _bic;

        public BankAccount(Action<object> applyChange) : base(applyChange)
        {
            Register<BankAccountWasLinkedToPublicService>(When);
        }

        private void When(BankAccountWasLinkedToPublicService @event)
        {
        }
    }
}
