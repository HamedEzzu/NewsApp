using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp2.Migrations
{
    /// <inheritdoc />
    public partial class m11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApplicationUserId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_ApplicationUserId",
                table: "UserProfile");

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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserProfile");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProfile",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_UserId",
                table: "UserProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_UserId",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserProfile",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ApplicationUserId",
                table: "UserProfile",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApplicationUserId",
                table: "UserProfile",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
