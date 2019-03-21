namespace BankAccountNumberRegistry.Projections.Api.OrganisationList
{
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.Connector;
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.SqlStreamStore;
    using Organisation.Events;

    public class OrganisationListProjections : ConnectedProjection<ApiProjectionsContext>
    {
        public OrganisationListProjections()
        {
            When<Envelope<OrganisationWasRegistered>>(async (context, message, ct) =>
            {
                await context
                    .OrganisationList
                    .AddAsync(
                        new OrganisationList
                        {
                            OvoNumber = message.Message.OvoNumber
                        }, ct);
            });
        }
    }
}
