namespace BankAccountNumberRegistry.Projections.Api.OrganisationBankAccountNumberList
{
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrganisationBankAccountNumberList
    {
        public string OvoNumber { get; set; }
    }

    public class OrganisationBankAccountNumberListConfiguration : IEntityTypeConfiguration<OrganisationBankAccountNumberList>
    {
        private const string TableName = "OrganisationBankAccountNumberList";

        public void Configure(EntityTypeBuilder<OrganisationBankAccountNumberList> b)
        {
            b.ToTable(TableName, Schema.Api)
                .HasKey(x => x.OvoNumber)
                .ForSqlServerIsClustered();
        }
    }
}
