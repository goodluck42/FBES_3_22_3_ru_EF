using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedMail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "user_table",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -10,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Opal.Yundt@hotmail.com", "Opal", "Yundt" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Amy.Stokes3@yahoo.com", "Amy", "Stokes" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Jerome.Huels2@gmail.com", "Jerome", "Huels" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Noel.Bernhard28@yahoo.com", "Noel", "Bernhard" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Mike93@yahoo.com", "Mike", "Kling" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Noah.Durgan76@hotmail.com", "Noah", "Durgan" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Greg.Pagac@hotmail.com", "Greg", "Pagac" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Nancy_MacGyver@hotmail.com", "Nancy", "MacGyver" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Shawn8@yahoo.com", "Shawn", "Fahey" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "mail", "name", "surname" },
                values: new object[] { "Harriet_Ferry98@hotmail.com", "Harriet", "Ferry" });

            migrationBuilder.CreateIndex(
                name: "IX_user_table_mail",
                table: "user_table",
                column: "mail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_table_mail",
                table: "user_table");

            migrationBuilder.DropColumn(
                name: "mail",
                table: "user_table");

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -10,
                columns: new[] { "name", "surname" },
                values: new object[] { "John", "Maggio" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "name", "surname" },
                values: new object[] { "Nicole", "Rath" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "name", "surname" },
                values: new object[] { "Steve", "Kertzmann" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "name", "surname" },
                values: new object[] { "Alexandra", "Sporer" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "name", "surname" },
                values: new object[] { "Marie", "Fay" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "name", "surname" },
                values: new object[] { "Dean", "Schowalter" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "name", "surname" },
                values: new object[] { "Jaime", "Heidenreich" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "name", "surname" },
                values: new object[] { "Emilio", "Zboncak" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "name", "surname" },
                values: new object[] { "Joey", "Dietrich" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "name", "surname" },
                values: new object[] { "Phillip", "Ondricka" });
        }
    }
}
