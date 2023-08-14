using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class Datainsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "A young hobbit, Frodo, who has found the One Ring that belongs to the Dark Lord Sauron, begins his journey with eight companions to Mount Doom, the only place where it can be destroyed.", 2, "The Lord of the Rings: The fellowship of the ring", 2001 },
                    { 2, "A young boy, Harry Potter, discovers he is a wizard and embarks on a journey to Hogwarts School of Witchcraft and Wizardry, where he learns about his past and confronts the dark wizard who killed his parents.", 7, "Harry Potter and the Sorcerer's Stone", 2001 },
                    { 3, "A wealthy entrepreneur creates a theme park where genetically-engineered dinosaurs roam. Chaos ensues when the dinosaurs break free, and a group of people must survive the dangerous creatures.", 11, "Jurassic Park", 1993 },
                    { 4, "Dom Cobb is a skilled thief who enters people's dreams to steal their deepest secrets. He is given a challenging task - to plant an idea into someone's mind through a complex process of dream manipulation.", 11, "Inception", 2010 },
                    { 5, "A group of superheroes, including Iron Man, Thor, Captain America, Hulk, Black Widow, and Hawkeye, join forces to stop Loki and his alien army from taking over Earth.", 1, "The Avengers", 2012 },
                    { 6, "A clownfish named Marlin embarks on a journey across the ocean to find his son, Nemo, who has been captured by a diver and placed in a fish tank in a dentist's office.", 3, "Finding Nemo", 2003 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
