namespace BankAccountNumberRegistry.Infrastructure.Repositories
{
    using Be.Vlaanderen.Basisregisters.AggregateSource;
    using Be.Vlaanderen.Basisregisters.AggregateSource.SqlStreamStore;
    using Be.Vlaanderen.Basisregisters.EventHandling;
    using Organisation;
    using SqlStreamStore;

    public class Organisations : Repository<Organisation, OvoNumber>, IOrganisations
    {
        public Organisations(ConcurrentUnitOfWork unitOfWork, IStreamStore eventStore, EventMapping eventMapping, EventDeserializer eventDeserializer)
            : base(Organisation.Factory, unitOfWork, eventStore, eventMapping, eventDeserializer) { }
    }
}
