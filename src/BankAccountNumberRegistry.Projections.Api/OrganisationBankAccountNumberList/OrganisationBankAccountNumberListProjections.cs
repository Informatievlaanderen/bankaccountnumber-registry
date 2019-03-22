namespace BankAccountNumberRegistry.Projections.Api.OrganisationBankAccountNumberList
{
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.Connector;
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.SqlStreamStore;
    using Organisation.Events;

    public class OrganisationBankAccountNumberListProjections : ConnectedProjection<ApiProjectionsContext>
    {
        public OrganisationBankAccountNumberListProjections()
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
