using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileManagerApi.Migrations
{
    public partial class InitialCreate : Migration
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
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserModelUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryModel", x => new { x.Path, x.Name });
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
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FolderModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FolderModelPath = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelPath = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderModel", x => new { x.Path, x.Name });
                    table.ForeignKey(
                        name: "FK_FolderModel_FolderModel_FolderModelPath_FolderModelName",
                        columns: x => new { x.FolderModelPath, x.FolderModelName },
                        principalTable: "FolderModel",
                        principalColumns: new[] { "Path", "Name" });
                    table.ForeignKey(
                        name: "FK_FolderModel_RepositoryModel_RepositoryModelPath_RepositoryModelName",
                        columns: x => new { x.RepositoryModelPath, x.RepositoryModelName },
                        principalTable: "RepositoryModel",
                        principalColumns: new[] { "Path", "Name" });
                });

            migrationBuilder.CreateTable(
                name: "FileModel",
                columns: table => new
                {
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FolderModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FolderModelPath = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepositoryModelPath = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModel", x => new { x.Path, x.Name });
                    table.ForeignKey(
                        name: "FK_FileModel_FolderModel_FolderModelPath_FolderModelName",
                        columns: x => new { x.FolderModelPath, x.FolderModelName },
                        principalTable: "FolderModel",
                        principalColumns: new[] { "Path", "Name" });
                    table.ForeignKey(
                        name: "FK_FileModel_RepositoryModel_RepositoryModelPath_RepositoryModelName",
                        columns: x => new { x.RepositoryModelPath, x.RepositoryModelName },
                        principalTable: "RepositoryModel",
                        principalColumns: new[] { "Path", "Name" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_FolderModelPath_FolderModelName",
                table: "FileModel",
                columns: new[] { "FolderModelPath", "FolderModelName" });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_RepositoryModelPath_RepositoryModelName",
                table: "FileModel",
                columns: new[] { "RepositoryModelPath", "RepositoryModelName" });

            migrationBuilder.CreateIndex(
                name: "IX_FolderModel_FolderModelPath_FolderModelName",
                table: "FolderModel",
                columns: new[] { "FolderModelPath", "FolderModelName" });

            migrationBuilder.CreateIndex(
                name: "IX_FolderModel_RepositoryModelPath_RepositoryModelName",
                table: "FolderModel",
                columns: new[] { "RepositoryModelPath", "RepositoryModelName" });

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
