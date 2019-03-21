namespace BankAccountNumberRegistry.Projections.Api.OrganisationList
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.Connector;

    public static class DomainListExtensions
    {
        public static async Task<OrganisationList> FindAndUpdateOrganisationList(
            this ApiProjectionsContext context,
            string ovoNumber,
            Action<OrganisationList> updateFunc,
            CancellationToken ct)
        {
            var organisation = await context
                .OrganisationList
                .FindAsync(ovoNumber, cancellationToken: ct);

            if (organisation == null)
                throw DatabaseItemNotFound(ovoNumber);

            updateFunc(organisation);

            return organisation;
        }

        private static ProjectionItemNotFoundException<OrganisationListProjections> DatabaseItemNotFound(string ovoNumber)
            => new ProjectionItemNotFoundException<OrganisationListProjections>(ovoNumber);
    }
}
