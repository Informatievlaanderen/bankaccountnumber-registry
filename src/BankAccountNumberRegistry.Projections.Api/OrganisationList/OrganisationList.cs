namespace BankAccountNumberRegistry.Projections.Api.OrganisationList
{
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrganisationList
    {
        public string OvoNumber { get; set; }
    }

    public class OrganisationListConfiguration : IEntityTypeConfiguration<OrganisationList>
    {
        private const string TableName = "OrganisationList";

        public void Configure(EntityTypeBuilder<OrganisationList> b)
        {
            b.ToTable(TableName, Schema.Api)
                .HasKey(x => x.OvoNumber)
                .ForSqlServerIsClustered();
        }
    }
}
