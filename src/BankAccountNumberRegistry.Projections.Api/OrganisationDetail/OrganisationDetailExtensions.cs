namespace BankAccountNumberRegistry.Projections.Api.OrganisationDetail
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Be.Vlaanderen.Basisregisters.ProjectionHandling.Connector;

    public static class OrganisationDetailExtensions
    {
        public static async Task<OrganisationDetail> FindAndUpdateOrganisationDetail(
            this ApiProjectionsContext context,
            string ovoNumber,
            Action<OrganisationDetail> updateFunc,
            CancellationToken ct)
        {
            var organisation = await context
                .OrganisationDetails
                .FindAsync(ovoNumber, cancellationToken: ct);

            if (organisation == null)
                throw DatabaseItemNotFound(ovoNumber);

            updateFunc(organisation);

            return organisation;
        }

        private static ProjectionItemNotFoundException<OrganisationDetailProjections> DatabaseItemNotFound(string ovoNumber)
            => new ProjectionItemNotFoundException<OrganisationDetailProjections>(ovoNumber);
    }
}
