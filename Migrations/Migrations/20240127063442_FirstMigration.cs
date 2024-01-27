using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    City = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_table_UserAddresses_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "UserAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_user_table_UserId",
                        column: x => x.UserId,
                        principalTable: "user_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "City", "Country", "UserId" },
                values: new object[] { -1, "Baku", "AZ", -5 });

            migrationBuilder.InsertData(
                table: "user_table",
                columns: new[] { "id", "name", "surname", "UserAddressId" },
                values: new object[,]
                {
                    { -10, "John", "Maggio", null },
                    { -9, "Nicole", "Rath", null },
                    { -8, "Steve", "Kertzmann", null },
                    { -7, "Alexandra", "Sporer", null },
                    { -6, "Marie", "Fay", null },
                    { -4, "Jaime", "Heidenreich", null },
                    { -3, "Emilio", "Zboncak", null },
                    { -2, "Joey", "Dietrich", null },
                    { -1, "Phillip", "Ondricka", null },
                    { -5, "Dean", "Schowalter", -1 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Attempts", "Login", "PasswordHash", "UserId" },
                values: new object[,]
                {
                    { -2, 0, "test_login2", "my_testPassHash", -5 },
                    { -1, 0, "test_login", "my_passhash", -5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_table_UserAddressId",
                table: "user_table",
                column: "UserAddressId",
                unique: true,
                filter: "[UserAddressId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "user_table");

            migrationBuilder.DropTable(
                name: "UserAddresses");
        }
    }
}
