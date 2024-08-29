using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp2.Migrations
{
    /// <inheritdoc />
    public partial class m20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "63a64234-3285-4615-a8f2-48f9a4a7ce12", "095c8e65-9af4-40e3-b611-bac083ff03b1" });

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("9dbe7820-a5a7-41f8-bf46-aa590c0a9a69"));

            migrationBuilder.DeleteData(
                table: "SiteInfo",
                keyColumn: "Id",
                keyValue: new Guid("6efcfbd4-efb6-4a71-a47a-a86ee54bd725"));

            migrationBuilder.DeleteData(
                table: "SiteState",
                keyColumn: "Id",
                keyValue: new Guid("a0990101-883c-4b50-8b3d-df843f293180"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a64234-3285-4615-a8f2-48f9a4a7ce12");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "095c8e65-9af4-40e3-b611-bac083ff03b1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab595d2-f86e-4f4c-8dcf-c801f179d7df", "dd8fa66f-4c93-44b8-98c9-3a3d67a03f0c", "Prog", "PROG" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Email", "EmailConfirmed", "LastAccessTime", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98f92f8e-632a-44b5-ac94-49588a0d6969", 0, 0, "588c7d9a-3b0f-4739-93fe-3cf8e270f1d5", new DateTime(2024, 7, 2, 18, 19, 55, 816, DateTimeKind.Utc).AddTicks(6763), "ApplicationUser", "Programmer@Gmail.com", true, null, true, null, null, "PROGRAMMER@GMAIL.COM", "PROGRAMMER@GMAIL.COM", "AQAAAAIAAYagAAAAEBTxTvc0ctacnCDbZvZYICYVgGwZnc7Weq89tly1zf46wFHH5QdtotjkQ31EEY9zGQ==", null, true, "a96513ae-63f6-4656-9c41-97e80765a5f9", false, "Programmer@Gmail.com" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Created", "Email", "Facebook", "Instagram", "Modified", "Phone", "Twitter" },
                values: new object[] { new Guid("1a914a39-eb8e-4138-b9d3-24c370b81d03"), new DateTime(2024, 7, 2, 20, 19, 55, 816, DateTimeKind.Local).AddTicks(6535), "W.Wide@Gmail.com", "Worldwide Facebook", "Worldwide Instagram", null, "00218951234567", "Worldwide Twitter" });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "About", "Activity", "CoverImageUrl", "Created", "LogoUrl", "Modified", "Name" },
                values: new object[] { new Guid("19ebba77-c8a2-4395-9314-a485fd6b5223"), "We are a specialized news website covering political, sports, and economic events, along with various other sections of general interest to readers. We always strive to provide distinguished and reliable content that reflects the ongoing developments on both the local and global stages.", "News site", null, new DateTime(2024, 7, 2, 20, 19, 55, 816, DateTimeKind.Local).AddTicks(6392), null, null, "Worldwide" });

            migrationBuilder.InsertData(
                table: "SiteState",
                columns: new[] { "Id", "ClosingMessage", "Created", "Modified", "State" },
                values: new object[] { new Guid("0f51dd7a-ae45-4af9-908c-f5ebcc308369"), "The site is temporarily closed for development", new DateTime(2024, 7, 2, 20, 19, 55, 816, DateTimeKind.Local).AddTicks(6553), null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab595d2-f86e-4f4c-8dcf-c801f179d7df", "98f92f8e-632a-44b5-ac94-49588a0d6969" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab595d2-f86e-4f4c-8dcf-c801f179d7df", "98f92f8e-632a-44b5-ac94-49588a0d6969" });

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("1a914a39-eb8e-4138-b9d3-24c370b81d03"));

            migrationBuilder.DeleteData(
                table: "SiteInfo",
                keyColumn: "Id",
                keyValue: new Guid("19ebba77-c8a2-4395-9314-a485fd6b5223"));

            migrationBuilder.DeleteData(
                table: "SiteState",
                keyColumn: "Id",
                keyValue: new Guid("0f51dd7a-ae45-4af9-908c-f5ebcc308369"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab595d2-f86e-4f4c-8dcf-c801f179d7df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f92f8e-632a-44b5-ac94-49588a0d6969");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63a64234-3285-4615-a8f2-48f9a4a7ce12", "86fec778-e666-46c9-8d55-633b83bb85fb", "Prog", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Email", "EmailConfirmed", "LastAccessTime", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "095c8e65-9af4-40e3-b611-bac083ff03b1", 0, 0, "390a2a21-844b-46cf-9d68-50c4799a9322", new DateTime(2024, 6, 23, 18, 17, 37, 174, DateTimeKind.Utc).AddTicks(9993), "ApplicationUser", "Programmer@Gmail.com", true, null, true, null, null, "PROGRAMMER@GMAIL.COM", "PROGRAMMER@GMAIL.COM", "AQAAAAIAAYagAAAAEORoZcJQvSyu+COQlhoIF0gJti4lecMNS0woi+OozVZsK9HQVKdMUYXuW2HDgKHiaQ==", null, true, "66c45bb9-3690-4b41-a4f7-8d43a668fe38", false, "Programmer@Gmail.com" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Created", "Email", "Facebook", "Instagram", "Modified", "Phone", "Twitter" },
                values: new object[] { new Guid("9dbe7820-a5a7-41f8-bf46-aa590c0a9a69"), new DateTime(2024, 6, 23, 20, 17, 37, 174, DateTimeKind.Local).AddTicks(9797), "W.Wide@Gmail.com", "Worldwide Facebook", "Worldwide Instagram", null, "00218951234567", "Worldwide Twitter" });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "About", "Activity", "CoverImageUrl", "Created", "LogoUrl", "Modified", "Name" },
                values: new object[] { new Guid("6efcfbd4-efb6-4a71-a47a-a86ee54bd725"), "We are a specialized news website covering political, sports, and economic events, along with various other sections of general interest to readers. We always strive to provide distinguished and reliable content that reflects the ongoing developments on both the local and global stages.", "News site", null, new DateTime(2024, 6, 23, 20, 17, 37, 174, DateTimeKind.Local).AddTicks(9613), null, null, "Worldwide" });

            migrationBuilder.InsertData(
                table: "SiteState",
                columns: new[] { "Id", "ClosingMessage", "Created", "Modified", "State" },
                values: new object[] { new Guid("a0990101-883c-4b50-8b3d-df843f293180"), "The site is temporarily closed for development", new DateTime(2024, 6, 23, 20, 17, 37, 174, DateTimeKind.Local).AddTicks(9820), null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "63a64234-3285-4615-a8f2-48f9a4a7ce12", "095c8e65-9af4-40e3-b611-bac083ff03b1" });
        }
    }
}
