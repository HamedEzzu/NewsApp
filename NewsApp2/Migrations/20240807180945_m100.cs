using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp2.Migrations
{
    /// <inheritdoc />
    public partial class m100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e074731-9afb-4669-9352-f9931d3cd4db", "87871024-c6c8-4774-a826-96c248cb758c" });

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("4d54d847-ec2f-4ea2-9693-719afb7aa4f5"));

            migrationBuilder.DeleteData(
                table: "SiteInfo",
                keyColumn: "Id",
                keyValue: new Guid("5c8b1535-14de-4604-8c03-8e6df0ab1791"));

            migrationBuilder.DeleteData(
                table: "SiteState",
                keyColumn: "Id",
                keyValue: new Guid("b89dfaff-6c60-48f6-a479-e1df1e50f06a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e074731-9afb-4669-9352-f9931d3cd4db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87871024-c6c8-4774-a826-96c248cb758c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d9e9423-3a1d-415b-aae7-504e3d660b42", "56913a40-8534-46d6-92a3-f980e1be3b45", "Prog", "PROG" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "Approval", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Email", "EmailConfirmed", "LastAccessTime", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "591f07e2-cf1d-44bb-8170-e2fb71236832", 0, 0, null, "e0e795fa-5a8d-4032-9a1e-abfe0593eb5d", new DateTime(2024, 8, 7, 18, 9, 44, 826, DateTimeKind.Utc).AddTicks(8295), "ApplicationUser", "Programmer@Gmail.com", true, null, true, null, null, "PROGRAMMER@GMAIL.COM", "PROGRAMMER@GMAIL.COM", "AQAAAAIAAYagAAAAEAY6NwDSqH62O9fdOEeDl4Dl39seb4f4W2kGkadt9jEtJZALNRozMEzQWR1EtMIqKw==", null, true, "87ba089e-bdb4-4822-b289-efecc036c6dc", false, "Programmer@Gmail.com" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Created", "Email", "Facebook", "Instagram", "Modified", "Phone", "Twitter" },
                values: new object[] { new Guid("1e649d00-c6dd-41f3-b90c-0e741931c50f"), new DateTime(2024, 8, 7, 20, 9, 44, 826, DateTimeKind.Local).AddTicks(8042), "W.Wide@Gmail.com", "Worldwide Facebook", "Worldwide Instagram", null, "00218951234567", "Worldwide Twitter" });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "About", "Activity", "CoverImageUrl", "Created", "LogoUrl", "Modified", "Name" },
                values: new object[] { new Guid("67573336-7858-41f1-8698-4b0d9b002edb"), "We are a specialized news website covering political, sports, and economic events, along with various other sections of general interest to readers. We always strive to provide distinguished and reliable content that reflects the ongoing developments on both the local and global stages.", "News site", null, new DateTime(2024, 8, 7, 20, 9, 44, 826, DateTimeKind.Local).AddTicks(7885), null, null, "Worldwide" });

            migrationBuilder.InsertData(
                table: "SiteState",
                columns: new[] { "Id", "ClosingMessage", "Created", "Modified", "State" },
                values: new object[] { new Guid("f39c0e9b-2093-4479-933d-9483e0529407"), "The site is temporarily closed for development", new DateTime(2024, 8, 7, 20, 9, 44, 826, DateTimeKind.Local).AddTicks(8062), null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d9e9423-3a1d-415b-aae7-504e3d660b42", "591f07e2-cf1d-44bb-8170-e2fb71236832" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d9e9423-3a1d-415b-aae7-504e3d660b42", "591f07e2-cf1d-44bb-8170-e2fb71236832" });

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("1e649d00-c6dd-41f3-b90c-0e741931c50f"));

            migrationBuilder.DeleteData(
                table: "SiteInfo",
                keyColumn: "Id",
                keyValue: new Guid("67573336-7858-41f1-8698-4b0d9b002edb"));

            migrationBuilder.DeleteData(
                table: "SiteState",
                keyColumn: "Id",
                keyValue: new Guid("f39c0e9b-2093-4479-933d-9483e0529407"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d9e9423-3a1d-415b-aae7-504e3d660b42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "591f07e2-cf1d-44bb-8170-e2fb71236832");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e074731-9afb-4669-9352-f9931d3cd4db", "ac9e4a9c-6d47-4d95-bc5f-0f6eb4fe4941", "Prog", "PROG" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "Approval", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Email", "EmailConfirmed", "LastAccessTime", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "87871024-c6c8-4774-a826-96c248cb758c", 0, 0, null, "1cc08260-b9ef-43f6-9a56-7cae377f6206", new DateTime(2024, 7, 11, 18, 12, 44, 666, DateTimeKind.Utc).AddTicks(1351), "ApplicationUser", "Programmer@Gmail.com", true, null, true, null, null, "PROGRAMMER@GMAIL.COM", "PROGRAMMER@GMAIL.COM", "AQAAAAIAAYagAAAAEBmoauWKGQSzSU9IVyJhWvpbebixzoAEYYM+f/a0+wGgJmBHWP+540tpjHc7QiTbtQ==", null, true, "7756063d-6473-4e1a-a0a8-efb2a20883fd", false, "Programmer@Gmail.com" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Created", "Email", "Facebook", "Instagram", "Modified", "Phone", "Twitter" },
                values: new object[] { new Guid("4d54d847-ec2f-4ea2-9693-719afb7aa4f5"), new DateTime(2024, 7, 11, 20, 12, 44, 666, DateTimeKind.Local).AddTicks(864), "W.Wide@Gmail.com", "Worldwide Facebook", "Worldwide Instagram", null, "00218951234567", "Worldwide Twitter" });

            migrationBuilder.InsertData(
                table: "SiteInfo",
                columns: new[] { "Id", "About", "Activity", "CoverImageUrl", "Created", "LogoUrl", "Modified", "Name" },
                values: new object[] { new Guid("5c8b1535-14de-4604-8c03-8e6df0ab1791"), "We are a specialized news website covering political, sports, and economic events, along with various other sections of general interest to readers. We always strive to provide distinguished and reliable content that reflects the ongoing developments on both the local and global stages.", "News site", null, new DateTime(2024, 7, 11, 20, 12, 44, 666, DateTimeKind.Local).AddTicks(388), null, null, "Worldwide" });

            migrationBuilder.InsertData(
                table: "SiteState",
                columns: new[] { "Id", "ClosingMessage", "Created", "Modified", "State" },
                values: new object[] { new Guid("b89dfaff-6c60-48f6-a479-e1df1e50f06a"), "The site is temporarily closed for development", new DateTime(2024, 7, 11, 20, 12, 44, 666, DateTimeKind.Local).AddTicks(939), null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e074731-9afb-4669-9352-f9931d3cd4db", "87871024-c6c8-4774-a826-96c248cb758c" });
        }
    }
}
