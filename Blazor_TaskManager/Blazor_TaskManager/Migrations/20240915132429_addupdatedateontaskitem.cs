using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor_TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class addupdatedateontaskitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "TaskItems",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TaskItems");
        }
    }
}
