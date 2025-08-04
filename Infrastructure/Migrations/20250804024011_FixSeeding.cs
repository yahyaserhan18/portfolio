using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("f19f994b-9781-4ac7-9895-2440abd843ae"));

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "Avatar", "FullName", "Profil" },
                values: new object[] { new Guid("9e44d4be-1c4e-4c3c-a6dc-20e091f6cabc"), null, "afbee271-d03c-4416-bfc7-9c42e6c2cf4c_avatar.jpg", "Yahya Elserhan", "Software Engineer - Information System Engineer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("9e44d4be-1c4e-4c3c-a6dc-20e091f6cabc"));

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "Avatar", "FullName", "Profil" },
                values: new object[] { new Guid("f19f994b-9781-4ac7-9895-2440abd843ae"), null, "f293ed09-f8bb-4d96-9e49-8bb9c9e4ed2a_avatar.jpg", "Yahya Elserhan", "Software Engineer - Information System Engineer" });
        }
    }
}
