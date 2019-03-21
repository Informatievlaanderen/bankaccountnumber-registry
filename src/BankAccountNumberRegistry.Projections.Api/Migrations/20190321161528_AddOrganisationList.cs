using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAccountNumberRegistry.Projections.Api.Migrations
{
    public partial class AddOrganisationList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Api");

            migrationBuilder.CreateTable(
                name: "OrganisationList",
                schema: "Api",
                columns: table => new
                {
                    OvoNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationList", x => x.OvoNumber)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "ProjectionStates",
                schema: "Api",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Position = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectionStates", x => x.Name)
                        .Annotation("SqlServer:Clustered", true);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationList",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "ProjectionStates",
                schema: "Api");
        }
    }
}
