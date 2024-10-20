using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CultureIntelligence.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Changeusernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "52e937c2-3fa7-4bce-8133-efc30029e053", "admin@99x.io", "ADMIN@99X.IO", "ADMIN@99X.IO", "AQAAAAIAAYagAAAAEK/NtmiaruxTpDvFcqsK5LPv9fzhrCCjXtOkCGJGOdBCJvZ7h6eodQzIx+eGjpbeoQ==", "81b75c8c-0b7c-4599-b686-8b1e50a27378", "admin@99x.io" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "77c5377e-ec60-4f33-a4ab-72923e5b465c", "admin@codepulse.com", "ADMIN@CODEPULSE.COM", "ADMIN@CODEPULSE.COM", "AQAAAAIAAYagAAAAEMnEhk3wWcE5uxW230Rf3bq4tYPtD95EoIBxs1XdJ1cZRiZnt6t35+C/bhdcRNZiFA==", "fc133d2c-93ab-4358-9da3-38f70e6b8f1c", "admin@codepulse.com" });
        }
    }
}
