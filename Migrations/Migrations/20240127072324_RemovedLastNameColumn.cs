using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class RemovedLastNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "surname",
                table: "user_table");

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -10,
                columns: new[] { "mail", "name" },
                values: new object[] { "Wendell47@gmail.com", "Wendell" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -9,
                columns: new[] { "mail", "name" },
                values: new object[] { "Domingo34@yahoo.com", "Domingo" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -8,
                columns: new[] { "mail", "name" },
                values: new object[] { "Jeannette65@yahoo.com", "Jeannette" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -7,
                columns: new[] { "mail", "name" },
                values: new object[] { "Lynda51@yahoo.com", "Lynda" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "mail", "name" },
                values: new object[] { "Cassandra_Weber@hotmail.com", "Cassandra" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "mail", "name" },
                values: new object[] { "Winston.Konopelski88@yahoo.com", "Winston" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "mail", "name" },
                values: new object[] { "Tammy.Miller10@hotmail.com", "Tammy" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "mail", "name" },
                values: new object[] { "Judith30@yahoo.com", "Judith" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "mail", "name" },
                values: new object[] { "Shannon.Crooks42@gmail.com", "Shannon" });

            migrationBuilder.UpdateData(
                table: "user_table",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "mail", "name" },
                values: new object[] { "Erica_Volkman@hotmail.com", "Erica" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "user_table",
                type: "nvarchar(128)",
                maxLength: 128,
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
        }
    }
}
