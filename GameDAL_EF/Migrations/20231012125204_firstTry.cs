using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDAL_EF.Migrations
{
    public partial class firstTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenreList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PwdHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGenre = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameList_GenreList_GenreId",
                        column: x => x.GenreId,
                        principalTable: "GenreList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteList",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteList", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavoriteList_GameList_GameId",
                        column: x => x.GameId,
                        principalTable: "GameList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteList_UserList_UserId",
                        column: x => x.UserId,
                        principalTable: "UserList",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GameList",
                columns: new[] { "Id", "Description", "GenreId", "IdGenre", "Title" },
                values: new object[,]
                {
                    { 1, "Best jeu de foot ever", null, 1, "Rocket League" },
                    { 2, "Anne PC Killer", null, 2, "Baldur's Gate" },
                    { 3, "Pour les fan de panpan", null, 3, "CS:GO" },
                    { 4, "Best perte de temps ever", null, 4, "World of Warcraft" }
                });

            migrationBuilder.InsertData(
                table: "GenreList",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "RPG" },
                    { 3, "Meuporg" },
                    { 4, "FPS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteList_UserId",
                table: "FavoriteList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameList_GenreId",
                table: "GameList",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteList");

            migrationBuilder.DropTable(
                name: "GameList");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropTable(
                name: "GenreList");
        }
    }
}
