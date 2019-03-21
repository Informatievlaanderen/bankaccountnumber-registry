namespace BankAccountNumberRegistry.Organisation
{
    using System;
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using Be.Vlaanderen.Basisregisters.CommandHandling;
    using Be.Vlaanderen.Basisregisters.CommandHandling.SqlStreamStore;
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Commands;
    using SqlStreamStore;

    public sealed class OrganisationCommandHandlerModule : CommandHandlerModule
    {
        public OrganisationCommandHandlerModule(
            Func<IOrganisations> getOrganisations,
            Func<ConcurrentUnitOfWork> getUnitOfWork,
            Func<IStreamStore> getStreamStore,
            EventMapping eventMapping,
            EventSerializer eventSerializer)
        {
            For<RegisterOrganisation>()
                .AddSqlStreamStore(getStreamStore, getUnitOfWork, eventMapping, eventSerializer)
                .Handle(async (message, ct) =>
                {
                    var organisations = getOrganisations();

                    var ovoNumber = message.Command.OvoNumber;
                    var organisation = Organisation.Register(ovoNumber);

                    organisations.Add(ovoNumber, organisation);
                });
        }
    }
}
