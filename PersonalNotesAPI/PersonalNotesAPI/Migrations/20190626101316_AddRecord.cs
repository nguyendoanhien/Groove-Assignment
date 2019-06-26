using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalNotesAPI.Migrations
{
    public partial class AddRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    NotebookId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notebook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebook", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Deleted", "Description", "Finished", "NotebookId", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "Truc", new DateTime(2019, 6, 26, 17, 13, 16, 800, DateTimeKind.Local).AddTicks(6869), false, "Description note 01", false, 1, "Note01", "", null });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Deleted", "Description", "Finished", "NotebookId", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 2, "Truc", new DateTime(2019, 6, 26, 17, 13, 16, 800, DateTimeKind.Local).AddTicks(9258), false, "Description note 02", false, 1, "Note02", "", null });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Deleted", "Description", "Finished", "NotebookId", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 3, "Truc", new DateTime(2019, 6, 26, 17, 13, 16, 800, DateTimeKind.Local).AddTicks(9278), false, "Description note 03", false, 2, "Note03", "", null });

            migrationBuilder.InsertData(
                table: "Notebook",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Deleted", "Name", "ParentId", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1, "Truc", new DateTime(2019, 6, 26, 17, 13, 16, 799, DateTimeKind.Local).AddTicks(4989), false, "Notebook01", null, "", null });

            migrationBuilder.InsertData(
                table: "Notebook",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Deleted", "Name", "ParentId", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 2, "Truc", new DateTime(2019, 6, 26, 17, 13, 16, 800, DateTimeKind.Local).AddTicks(2907), false, "Notebook02", null, "", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Notebook");
        }
    }
}
