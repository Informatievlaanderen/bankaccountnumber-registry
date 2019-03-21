namespace BankAccountNumberRegistry.Organisation
{
    using Be.Vlaanderen.Basisregisters.AggregateSource;

    public interface IOrganisations : IAsyncRepository<Organisation, OvoNumber> { }
}
