using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsApp2.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7438bbf2-f081-4b5c-acaf-cde53285bc3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd674277-ae2f-48fd-82d3-6ff6df086b48");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bb94ad1a-bee3-4f6a-875d-933630ba361d", "4040d33c-46a8-4269-9762-bcd407d3712d" });

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("88c64dc5-e70b-42a7-a967-63e6d461f74b"));

            migrationBuilder.DeleteData(
                table: "SiteInfo",
                keyColumn: "Id",
                keyValue: new Guid("13d86aa3-1a86-47ec-af51-714e9b6eacc0"));

            migrationBuilder.DeleteData(
                table: "SiteState",
                keyColumn: "Id",
                keyValue: new Guid("581c5337-e8a6-4163-89c7-a943032910a7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb94ad1a-bee3-4f6a-875d-933630ba361d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4040d33c-46a8-4269-9762-bcd407d3712d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c86748b4-8baf-42d8-b46b-8ea55bb31b5e", "c23147b3-3fea-4f8a-8407-3af2165ea5f3", "Prog", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Email", "EmailConfirmed", "LastAccessTime", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f1fd7f1-a11e-4db8-a239-9661b54432d3", 0, 0, "8f060ce2-2dd8-439e-a5b1-b966c6b3506d", new DateTime(2024, 6, 22, 4, 32, 5, 779, DateTimeKind.Utc).AddTicks(8466), "ApplicationUser", "Programmer@Gmail.com", true, null, true, null, null, "PROGRAMMER@GMAIL.COM", "PROGRAMMER@GMAIL.COM", "AQAAAAIAAYagAAAAECQS7Z9gXK1gt1GvGsrmOYU0RGxL7oHhBpzxkiz0CNfIscXDc1J2eCPTEzh99TWS8A==", null, true, "371d33e9-9436-484f-b792-79b18e5a1941", false, "Programmer@Gmail.com" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Created", "Email", "Facebook", "Instagram", "Modified", "Phone", "Twitter" },
                values: new object[] { new Guid("40d63489-3ef1-4daa-b4eb-cde33bd2e7f0"), new DateTime(2024, 6, 22, 6, 32, 5, 779, DateTimeKind.Local).AddTicks(8286), "W.Wide@Gmail.com", "Worldwide Facebook", "Worldwide Instagram", null, "00218951234567", "Worldwide Twitter" });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "About", "Activity", "CoverImageUrl", "Created", "LogoUrl", "Modified", "Name" },
                values: new object[] { new Guid("da99708e-e085-4a30-bbec-b9936f1d1a95"), "We are a specialized news website covering political, sports, and economic events, along with various other sections of general interest to readers. We always strive to provide distinguished and reliable content that reflects the ongoing developments on both the local and global stages.", "News site", null, new DateTime(2024, 6, 22, 6, 32, 5, 779, DateTimeKind.Local).AddTicks(8150), null, null, "Worldwide" });

            migrationBuilder.InsertData(
                table: "SiteState",
                columns: new[] { "Id", "ClosingMessage", "Created", "Modified", "State" },
                values: new object[] { new Guid("10c0a4fb-63ab-4d97-a6d3-1d841ed8f033"), "The site is temporarily closed for development", new DateTime(2024, 6, 22, 6, 32, 5, 779, DateTimeKind.Local).AddTicks(8310), null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c86748b4-8baf-42d8-b46b-8ea55bb31b5e", "6f1fd7f1-a11e-4db8-a239-9661b54432d3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c86748b4-8baf-42d8-b46b-8ea55bb31b5e", "6f1fd7f1-a11e-4db8-a239-9661b54432d3" });

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("40d63489-3ef1-4daa-b4eb-cde33bd2e7f0"));

            migrationBuilder.DeleteData(
                table: "SiteInfo",
                keyColumn: "Id",
                keyValue: new Guid("da99708e-e085-4a30-bbec-b9936f1d1a95"));

            migrationBuilder.DeleteData(
                table: "SiteState",
                keyColumn: "Id",
                keyValue: new Guid("10c0a4fb-63ab-4d97-a6d3-1d841ed8f033"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c86748b4-8baf-42d8-b46b-8ea55bb31b5e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f1fd7f1-a11e-4db8-a239-9661b54432d3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7438bbf2-f081-4b5c-acaf-cde53285bc3a", "89e9886e-fd59-4660-8fa3-1f4ea772363c", "Admin", null },
                    { "bb94ad1a-bee3-4f6a-875d-933630ba361d", "abcfd228-8996-46c3-a53a-f4612f55b7e2", "Prog", null },
                    { "cd674277-ae2f-48fd-82d3-6ff6df086b48", "2cb94867-e029-41c9-ba2d-51b1520ce44f", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Email", "EmailConfirmed", "LastAccessTime", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4040d33c-46a8-4269-9762-bcd407d3712d", 0, 0, "4f420d9c-9295-43cd-a980-407edd0fe481", new DateTime(2024, 6, 22, 4, 29, 36, 962, DateTimeKind.Utc).AddTicks(5740), "ApplicationUser", "Programmer@Gmail.com", true, null, true, null, null, "PROGRAMMER@GMAIL.COM", "PROGRAMMER@GMAIL.COM", "AQAAAAIAAYagAAAAEIRENpouNYHY/ZwuGpWgUVT3+KRtA8taYoB2MudySQIbg4DEK+zCtrI75Qg8Eyktdw==", null, true, "e6369fb9-efb9-4aa5-a5b8-3504d1193606", false, "Programmer@Gmail.com" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Created", "Email", "Facebook", "Instagram", "Modified", "Phone", "Twitter" },
                values: new object[] { new Guid("88c64dc5-e70b-42a7-a967-63e6d461f74b"), new DateTime(2024, 6, 22, 6, 29, 36, 962, DateTimeKind.Local).AddTicks(5556), "W.Wide@Gmail.com", "Worldwide Facebook", "Worldwide Instagram", null, "00218951234567", "Worldwide Twitter" });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "About", "Activity", "CoverImageUrl", "Created", "LogoUrl", "Modified", "Name" },
                values: new object[] { new Guid("13d86aa3-1a86-47ec-af51-714e9b6eacc0"), "We are a specialized news website covering political, sports, and economic events, along with various other sections of general interest to readers. We always strive to provide distinguished and reliable content that reflects the ongoing developments on both the local and global stages.", "News site", null, new DateTime(2024, 6, 22, 6, 29, 36, 962, DateTimeKind.Local).AddTicks(5408), null, null, "Worldwide" });

            migrationBuilder.InsertData(
                table: "SiteState",
                columns: new[] { "Id", "ClosingMessage", "Created", "Modified", "State" },
                values: new object[] { new Guid("581c5337-e8a6-4163-89c7-a943032910a7"), "The site is temporarily closed for development", new DateTime(2024, 6, 22, 6, 29, 36, 962, DateTimeKind.Local).AddTicks(5578), null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bb94ad1a-bee3-4f6a-875d-933630ba361d", "4040d33c-46a8-4269-9762-bcd407d3712d" });
        }
    }
}
