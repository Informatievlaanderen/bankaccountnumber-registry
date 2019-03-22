namespace BankAccountNumberRegistry.Projections.Api.OrganisationDetail
{
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrganisationDetail
    {
        public string OvoNumber { get; set; }
    }

    public class OrganisationDetailConfiguration : IEntityTypeConfiguration<OrganisationDetail>
    {
        private const string TableName = "OrganisationDetails";

        public void Configure(EntityTypeBuilder<OrganisationDetail> b)
        {
            b.ToTable(TableName, Schema.Api)
                .HasKey(x => x.OvoNumber)
                .ForSqlServerIsClustered();
        }
    }
}
