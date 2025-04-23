using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seedingthedifficultydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("59409221-372f-4347-9289-be9d46dddb44"), "Hard" },
                    { new Guid("a7063c30-1c87-43c9-bed1-0798edeb8fb3"), "Medium" },
                    { new Guid("a8c61a88-9a05-4d42-a424-24842ddfb435"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("59409221-372f-4347-9289-be9d46dddb44"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("a7063c30-1c87-43c9-bed1-0798edeb8fb3"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("a8c61a88-9a05-4d42-a424-24842ddfb435"));
        }
    }
}
