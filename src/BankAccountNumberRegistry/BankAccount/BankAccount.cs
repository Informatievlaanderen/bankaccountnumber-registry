namespace BankAccountNumberRegistry.BankAccount
{
    using System;
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using Events;

    public class BankAccount : Entity
    {
        public BankAccount(Action<object> applyChange) : base(applyChange)
        {
            Register<BankAccountWasLinkedToPublicService>(When);
        }

        private void When(BankAccountWasLinkedToPublicService @event)
        {
        }
    }
}
