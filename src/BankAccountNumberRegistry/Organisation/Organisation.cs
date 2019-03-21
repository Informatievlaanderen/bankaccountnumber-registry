namespace BankAccountNumberRegistry.Organisation
{
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using System;
    using Events;

    public partial class Organisation : AggregateRootEntity
    {
        public static readonly Func<Organisation> Factory = () => new Organisation();

        public static Organisation Register(OvoNumber ovoNumber)
        {
            var organisation = Factory();
            organisation.ApplyChange(new OrganisationWasRegistered(ovoNumber));
            return organisation;
        }
    }
}
