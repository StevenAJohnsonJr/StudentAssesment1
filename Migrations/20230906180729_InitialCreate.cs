using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StudentAssesment1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, 53, "Shawn Corey Carter, known professionally as Jay-Z, is an American rapper, record producer, and entrepreneur. Often regarded as the greatest rapper of all time, he has been central to the creative and commercial success of artists including Kanye West, Rihanna, and J. Cole.", "Jay-z" },
                    { 2, 44, "Marvin Pentz Gay Jr., known professionally as Marvin Gaye, was an American R&B and soul singer and songwriter", "Marvin Gaye" },
                    { 3, 82, "Parliament-Funkadelic is an American music collective of rotating musicians headed by George Clinton, primarily consisting of the funk bands Parliament and Funkadelic, both active since the 1960s", "Parliament-Funkadelic" },
                    { 4, 36, "Robert Nesta Marley OM was a Jamaican singer, musician, and songwriter. Considered one of the pioneers of reggae, his musical career was marked by fusing elements of reggae, ska, and rocksteady, as well as his distinctive vocal and songwriting style.", "Bob Marley" },
                    { 5, 65, "Miles Dewey Davis III was an American jazz musician, trumpeter, bandleader, and composer. He is among the most influential and acclaimed figures in the history of jazz and 20th-century music.", "Myles davis" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Hip-Hop" },
                    { 2, "Rhythm and blues" },
                    { 3, "Funk" },
                    { 4, "Reggae" },
                    { 5, "Jazz" }
                });

            migrationBuilder.InsertData(
                table: "SongGenres",
                columns: new[] { "Id", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Blueprint", 1, new DateTime(2023, 4, 20, 0, 3, 45, 0, DateTimeKind.Unspecified), "Takeover" },
                    { 2, "Lets Get It On", 2, new DateTime(2023, 5, 2, 0, 4, 15, 0, DateTimeKind.Unspecified), "Lets Get It On" },
                    { 3, "Computer Games", 3, new DateTime(2023, 6, 30, 0, 5, 20, 0, DateTimeKind.Unspecified), "Atomic Dog" },
                    { 4, "Confrontation", 4, new DateTime(2023, 2, 20, 0, 3, 10, 0, DateTimeKind.Unspecified), "Buffalo Soldier" },
                    { 5, "Round About Midnight", 5, new DateTime(2023, 1, 28, 0, 2, 45, 0, DateTimeKind.Unspecified), "Bye Bye Blackbird" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "SongGenres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
