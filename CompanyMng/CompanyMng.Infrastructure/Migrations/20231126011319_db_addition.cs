using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyMng.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbaddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyName", "CompanyNumber", "Country", "CreationTime", "Website" },
                values: new object[,]
                {
                    { 1, "company1", 1, "Turkey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "company1.com" },
                    { 2, "company2", 2, "USA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "company2.com" },
                    { 3, "company3", 3, "Germany", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "company3.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "AmountUnit", "Category", "CompanyName", "CreationTime", "ProductName" },
                values: new object[,]
                {
                    { 1, 15, "unit1", "category1", "company1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product1" },
                    { 2, 25, "unit2", "category2", "company1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product2" },
                    { 3, 12, "unit3", "category3", "company2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product3" },
                    { 4, 7, "unit4", "category4", "company2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product4" },
                    { 5, 16, "unit5", "category5", "company3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product5" },
                    { 6, 30, "unit6", "category6", "company3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product6" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationTime", "Email", "FirstName", "LastName", "Password", "Roles", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@mail.com", "admin", "admin", "admin", 2, "admin" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@mail.com", "user", "user", "user", 1, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
