using Microsoft.EntityFrameworkCore.Migrations;

namespace DoumentsManagementAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Authors (FullName,Address) Values ('Adam Smith','London')");
            migrationBuilder
                .Sql("INSERT INTO Authors (FullName,Address) Values ('Addison Wesley','USA')");
            migrationBuilder
                .Sql("INSERT INTO Authors (FullName,Address) Values ('Andrew Lock','Australia')");
            migrationBuilder
                .Sql("INSERT INTO Authors (FullName,Address) Values ('Dan Lok','Hong Kong')");
            migrationBuilder
                .Sql("INSERT INTO Authors (FullName,Address) Values ('George S. Clason','USA')");

            migrationBuilder
                .Sql("INSERT INTO Categories (Name) Values ('Computer science')");
            migrationBuilder
                .Sql("INSERT INTO Categories (Name) Values ('Novels')");
            migrationBuilder
                .Sql("INSERT INTO Categories (Name) Values ('Business & Management')");

            migrationBuilder
                .Sql("INSERT INTO Documents (Title, PublishedDate, AuthorId, CategoryId) Values ('The Wealth of Nations', '9-3-1776', (SELECT AuthorId FROM Authors WHERE FullName = 'Adam Smith'),(SELECT CategoryId FROM Categories WHERE Name = 'Business & Management'))");
            migrationBuilder
                .Sql("INSERT INTO Documents (Title, PublishedDate, AuthorId, CategoryId) Values ('The Richest Man In Babylon', '24-1-1926', (SELECT AuthorId FROM Authors WHERE FullName = 'George S. Clason'),(SELECT CategoryId FROM Categories WHERE Name = 'Business & Management'))");
            migrationBuilder
                .Sql("INSERT INTO Documents (Title, PublishedDate, AuthorId, CategoryId) Values ('FU-Money', '16-8-2019', (SELECT AuthorId FROM Authors WHERE FullName = 'Dan Lok'),(SELECT CategoryId FROM Categories WHERE Name = 'Business & Management'))");
            migrationBuilder
                .Sql("INSERT INTO Documents (Title, PublishedDate, AuthorId, CategoryId) Values ('ASP.NET Core in Action', '30-5-2018', (SELECT AuthorId FROM Authors WHERE FullName = 'Andrew Lock'),(SELECT CategoryId FROM Categories WHERE Name = 'Computer science'))");


        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Authors");

            migrationBuilder
                .Sql("DELETE FROM Documents");

            migrationBuilder
                .Sql("DELETE FROM Categories");
        }
    }
}
