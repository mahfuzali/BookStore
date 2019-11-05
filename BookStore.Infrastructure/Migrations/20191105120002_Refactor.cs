using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infrastructure.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { new Guid("f27f4118-6ce2-413c-8869-8d30eaa81ba5"), new DateTimeOffset(new DateTime(1564, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "William", "Shakespeare" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[] { new Guid("4ae2a995-59f8-4f43-986d-54c681eaab97"), new Guid("f27f4118-6ce2-413c-8869-8d30eaa81ba5"), "An age-old vendetta between two powerful families erupts into bloodshed. A group of masked Montagues risk further conflict by gatecrashing a Capulet party. A young lovesick Romeo Montague falls instantly in love with Juliet Capulet, who is due to marry her father's choice, the County Paris.", "Romeo and Juliet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4ae2a995-59f8-4f43-986d-54c681eaab97"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("f27f4118-6ce2-413c-8869-8d30eaa81ba5"));
        }
    }
}
