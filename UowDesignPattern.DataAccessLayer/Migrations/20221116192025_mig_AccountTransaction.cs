using Microsoft.EntityFrameworkCore.Migrations;

namespace UowDesignPattern.DataAccessLayer.Migrations
{
    public partial class mig_AccountTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer2ID = table.Column<int>(type: "int", nullable: false),
                    ReciverIban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendIban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accountTransactions_Customer2s_Customer2ID",
                        column: x => x.Customer2ID,
                        principalTable: "Customer2s",
                        principalColumn: "Customer2ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountTransactions_Customer2ID",
                table: "accountTransactions",
                column: "Customer2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountTransactions");
        }
    }
}
