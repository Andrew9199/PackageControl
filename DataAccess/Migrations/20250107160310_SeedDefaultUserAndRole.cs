using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUserAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "073401da-110e-4962-afdd-2a966d1f0d7b", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentificationNumber", "IdentificationType", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f19a2b2-73a1-4fb1-9529-dca5b147151a", 0, "72956ea5-a815-4093-b409-31b3f225680f", "alex@gmail.com", true, "Alex", "1999999999", "Cedula", "Will", false, null, "ALEX@GMAIL.COM", "ALEX", "AQAAAAIAAYagAAAAEJCYB5eaPrSlWSpmizKppE/ThMBll4zUfiqKorrlTqIJESDY0dD5e75HSOUimnzpmQ==", null, false, "3MDBYHN34YWQIJOD6LHXCBAZ33SQOASS", false, "Alex" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "073401da-110e-4962-afdd-2a966d1f0d7b", "9f19a2b2-73a1-4fb1-9529-dca5b147151a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "073401da-110e-4962-afdd-2a966d1f0d7b", "9f19a2b2-73a1-4fb1-9529-dca5b147151a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "073401da-110e-4962-afdd-2a966d1f0d7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f19a2b2-73a1-4fb1-9529-dca5b147151a");
        }
    }
}
