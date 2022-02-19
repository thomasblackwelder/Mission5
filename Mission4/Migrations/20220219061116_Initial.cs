using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RatingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    RatingId = table.Column<int>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_responses_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "RatingName" },
                values: new object[] { 1, "G" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "RatingName" },
                values: new object[] { 2, "PG" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "RatingName" },
                values: new object[] { 3, "PG-13" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "RatingName" },
                values: new object[] { 4, "R" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "RatingName" },
                values: new object[] { 5, "NR" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "RatingId", "Title", "Year" },
                values: new object[] { 1, "Romance", "Martha Coolidge", false, "", "", 3, "Valley Girl", 1983 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "RatingId", "Title", "Year" },
                values: new object[] { 2, "Romance", "Jean-Pierre Jeunet", false, "", "", 3, "Amelie", 2001 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "RatingId", "Title", "Year" },
                values: new object[] { 3, "Romance", "Luca Guadagnino", false, "", "", 3, "Call Me by Your Name", 2017 });

            migrationBuilder.CreateIndex(
                name: "IX_responses_RatingId",
                table: "responses",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
