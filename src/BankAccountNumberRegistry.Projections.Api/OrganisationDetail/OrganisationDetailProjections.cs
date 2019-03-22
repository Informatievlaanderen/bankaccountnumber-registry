namespace BankAccountNumberRegistry.Projections.Api.OrganisationDetail
{
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.Connector;
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.SqlStreamStore;
    using Organisation.Events;

    public class OrganisationDetailProjections : ConnectedProjection<ApiProjectionsContext>
    {
        public OrganisationDetailProjections()
        {
            When<Envelope<OrganisationBankAccountWasAdded>>(async (context, message, ct) =>
            {
            });

            When<Envelope<OrganisationBankAccountWasUpdated>>(async (context, message, ct) =>
            {
            });
        }
    }
}
