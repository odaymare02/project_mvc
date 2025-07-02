using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_mvc.Migrations
{
    /// <inheritdoc />
    public partial class company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CompanyId",
                table: "products",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_company_CompanyId",
                table: "products",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_company_CompanyId",
                table: "products");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropIndex(
                name: "IX_products_CompanyId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "products");
        }
    }
}
