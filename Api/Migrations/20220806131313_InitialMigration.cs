using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryModel",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserModelUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryModel", x => new { x.Location, x.Name });
                    table.ForeignKey(
                        name: "FK_RepositoryModel_Users_UserModelUsername",
                        column: x => x.UserModelUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "FolderModel",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FolderModelLocation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FolderModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelLocation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderModel", x => new { x.Location, x.Name });
                    table.ForeignKey(
                        name: "FK_FolderModel_FolderModel_FolderModelLocation_FolderModelName",
                        columns: x => new { x.FolderModelLocation, x.FolderModelName },
                        principalTable: "FolderModel",
                        principalColumns: new[] { "Location", "Name" });
                    table.ForeignKey(
                        name: "FK_FolderModel_RepositoryModel_RepositoryModelLocation_RepositoryModelName",
                        columns: x => new { x.RepositoryModelLocation, x.RepositoryModelName },
                        principalTable: "RepositoryModel",
                        principalColumns: new[] { "Location", "Name" });
                });

            migrationBuilder.CreateTable(
                name: "FileModel",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderModelLocation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FolderModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelLocation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModel", x => new { x.Location, x.Name });
                    table.ForeignKey(
                        name: "FK_FileModel_FolderModel_FolderModelLocation_FolderModelName",
                        columns: x => new { x.FolderModelLocation, x.FolderModelName },
                        principalTable: "FolderModel",
                        principalColumns: new[] { "Location", "Name" });
                    table.ForeignKey(
                        name: "FK_FileModel_RepositoryModel_RepositoryModelLocation_RepositoryModelName",
                        columns: x => new { x.RepositoryModelLocation, x.RepositoryModelName },
                        principalTable: "RepositoryModel",
                        principalColumns: new[] { "Location", "Name" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_FolderModelLocation_FolderModelName",
                table: "FileModel",
                columns: new[] { "FolderModelLocation", "FolderModelName" });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_RepositoryModelLocation_RepositoryModelName",
                table: "FileModel",
                columns: new[] { "RepositoryModelLocation", "RepositoryModelName" });

            migrationBuilder.CreateIndex(
                name: "IX_FolderModel_FolderModelLocation_FolderModelName",
                table: "FolderModel",
                columns: new[] { "FolderModelLocation", "FolderModelName" });

            migrationBuilder.CreateIndex(
                name: "IX_FolderModel_RepositoryModelLocation_RepositoryModelName",
                table: "FolderModel",
                columns: new[] { "RepositoryModelLocation", "RepositoryModelName" });

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryModel_UserModelUsername",
                table: "RepositoryModel",
                column: "UserModelUsername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileModel");

            migrationBuilder.DropTable(
                name: "FolderModel");

            migrationBuilder.DropTable(
                name: "RepositoryModel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
