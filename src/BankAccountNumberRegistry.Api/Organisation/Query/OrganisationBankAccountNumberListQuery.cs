namespace BankAccountNumberRegistry.Api.Organisation.Query
{
    using System.Collections.Generic;
    using System.Linq;
    using Be.Vlaanderen.Basisregisters.Api.Search;
    using Be.Vlaanderen.Basisregisters.Api.Search.Filtering;
    using Be.Vlaanderen.Basisregisters.Api.Search.Sorting;
    using Microsoft.EntityFrameworkCore;
    using Projections.Api;
    using Projections.Api.OrganisationBankAccountNumberList;

    public class OrganisationBankAccountNumberListQuery : Query<OrganisationBankAccountNumberList, OrganisationBankAccountNumberFilter>
    {
        private readonly ApiProjectionsContext _context;

        protected override ISorting Sorting => new OrganisationBankAccountNumberSorting();

        public OrganisationBankAccountNumberListQuery(ApiProjectionsContext context) => _context = context;

        protected override IQueryable<OrganisationBankAccountNumberList> Filter(FilteringHeader<OrganisationBankAccountNumberFilter> filtering)
        {
            var organisationBankAccountNumbers = _context
                .OrganisationBankAccountNumberList
                .AsNoTracking();

            if (!filtering.ShouldFilter)
                return organisationBankAccountNumbers;

            if (!string.IsNullOrEmpty(filtering.Filter.OvoNumber))
                organisationBankAccountNumbers = organisationBankAccountNumbers.Where(m => m.OvoNumber == filtering.Filter.OvoNumber);

            return organisationBankAccountNumbers;
        }

        internal class OrganisationBankAccountNumberSorting : ISorting
        {
            public IEnumerable<string> SortableFields { get; } = new[]
            {
                nameof(OrganisationBankAccountNumberList.OvoNumber),
            };

            public SortingHeader DefaultSortingHeader { get; } = new SortingHeader(nameof(OrganisationBankAccountNumberList.OvoNumber), SortOrder.Ascending);
        }
    }

    public class OrganisationBankAccountNumberFilter
    {
        public string OvoNumber { get; set; }
    }
}
