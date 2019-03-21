namespace BankAccountNumberRegistry.Api.Organisation.Query
{
    using System.Collections.Generic;
    using System.Linq;
    using Be.Vlaanderen.Basisregisters.Api.Search;
    using Be.Vlaanderen.Basisregisters.Api.Search.Filtering;
    using Be.Vlaanderen.Basisregisters.Api.Search.Sorting;
    using Microsoft.EntityFrameworkCore;
    using Projections.Api;
    using Projections.Api.OrganisationList;

    public class OrganisationListQuery : Query<OrganisationList, OrganisationFilter>
    {
        private readonly ApiProjectionsContext _context;

        protected override ISorting Sorting => new OrganisationSorting();

        public OrganisationListQuery(ApiProjectionsContext context) => _context = context;

        protected override IQueryable<OrganisationList> Filter(FilteringHeader<OrganisationFilter> filtering)
        {
            var organisations = _context
                .OrganisationList
                .AsNoTracking();

            if (!filtering.ShouldFilter)
                return organisations;

            if (!string.IsNullOrEmpty(filtering.Filter.OvoNumber))
                organisations = organisations.Where(m => m.OvoNumber == filtering.Filter.OvoNumber);

            return organisations;
        }

        internal class OrganisationSorting : ISorting
        {
            public IEnumerable<string> SortableFields { get; } = new[]
            {
                nameof(OrganisationList.OvoNumber),
            };

            public SortingHeader DefaultSortingHeader { get; } = new SortingHeader(nameof(OrganisationList.OvoNumber), SortOrder.Ascending);
        }
    }

    public class OrganisationFilter
    {
        public string OvoNumber { get; set; }
    }
}
