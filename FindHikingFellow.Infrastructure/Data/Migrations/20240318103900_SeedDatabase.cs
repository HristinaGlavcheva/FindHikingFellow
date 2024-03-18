using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b", 0, "95f4c678-4f35-44bd-a77a-b806614facc1", "organiser@gmail.com", false, false, null, "ORGANISER@GMAIL.COM", "ORGANISER", "AQAAAAEAACcQAAAAEAGM0E9ueI4z/XbPsqDn9HuEgmYFc5i9ENuIJk+k5DVLa2RsleNBg6VzZSnk3KBPXg==", null, false, "f625baa6-44df-46ed-9d15-25516b1fd440", false, "Organiser" },
                    { "aec4bd2b-913c-425a-936f-8d2bd83c1164", 0, "3a54325f-11a7-430a-be6e-4fd31ff809d6", "participant@gmail.com", false, false, null, "PARTICIPANT@GMAIL.COM", "PARTICIPANT", "AQAAAAEAACcQAAAAEPCpgTNEYhoWXMhvneMjyI+62YS/U1tn8p7fGYSgGpk3oBWIkJ1K3Lcyl13qbCZuCw==", null, false, "7414b0d6-eb09-4705-b3fd-fbe5e57777a2", false, "Participant" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://webnews.bg/uploads/images/84/8784/228784/768x432.jpg?_=1460885734", "Pirin" },
                    { 2, "https://novavarna.net/wp-content/uploads/2020/06/rila_maliovica-1280x720.jpg", "Rila" },
                    { 3, "https://trud.bg/public/images/articles/2020-11/mountain-landscape-beautiful-hd-wallpaper-1024x640_1509577115668281610_original.jpg", "Balkan Mauntains" },
                    { 4, "https://bulgariawalking.com/wp-content/uploads/2016/10/rhodopes-and-rila-2.jpg", "Rodopi" },
                    { 5, "https://media-cdn.tripadvisor.com/media/photo-s/1a/d2/6c/b8/caption.jpg", "Vithosha" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hut" },
                    { 2, "Forest" },
                    { 3, "Lake" },
                    { 4, "River" },
                    { 5, "Waterfall" },
                    { 6, "Cave" },
                    { 7, "Dog friendly" },
                    { 8, "Kid friendly" },
                    { 9, "Camping possibility" },
                    { 10, "Rock climbing" },
                    { 11, "Via ferrata" },
                    { 12, "Ecotrail" },
                    { 13, "Beach" },
                    { 14, "Views" },
                    { 15, "Historic site" }
                });

            migrationBuilder.InsertData(
                table: "PersonalLists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Completed" },
                    { 2, "Favourites" },
                    { 3, "Wish to perform" },
                    { 4, "Planned" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "ActivityType", "Description", "DestinationId", "Difficulty", "Duration", "ElevationGain", "Length", "MeetingPoint", "MeetingTime", "Name", "OrganiserId", "RouteType" },
                values: new object[] { 1, 1, "Let's enjoy together this trail near Bansko, Blagoevgrad. Generally considered a challenging route, this is a very popular area for hiking.", 1, 3, "About 6 hours inlucding breaks for pictures and a lunch break", 931, 8.5, "Vihren hut", new DateTime(2024, 8, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), "Vihren Peak", "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164");

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PersonalLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonalLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonalLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonalLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b");

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
