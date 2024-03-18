using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class SeedMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_AspNetUsers_UserId",
                table: "FeedBacks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FeedBacks",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks",
                newName: "IX_FeedBacks_AuthorId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cc6130c-ae64-423b-9b72-9a27440cb543", "AQAAAAEAACcQAAAAEJggYtpbhLl6vqAgPaa7BuslQgO7EmwHUBVcxy4TxH1EmRfQ6VN2s8LTkkfWde/Muw==", "f5d3cb3e-61ab-418e-8ebd-bd6291596f53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "03cc5945-035a-401f-b04d-e229183c3ab5", "participant1@gmail.com", "PARTICIPANT1@GMAIL.COM", "PARTICIPANT1", "AQAAAAEAACcQAAAAEH7m9i8vrqH2c/HkjHkbuVgNVkfqryV9wL7QB/iVDSWd1R8bKBg+DvzMbL7ujgLPQw==", "81edca4c-8841-4b25-ba6e-5dacd9ad1cd5", "Participant1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "480fd4fe-3c32-4626-8ea9-ada588d0d24f", 0, "6f956c1a-4afc-4775-bf9f-2dea1ea3abf8", "participant2@gmail.com", false, false, null, "PARTICIPANT2@GMAIL.COM", "PARTICIPANT2", "AQAAAAEAACcQAAAAEP/ua1kvCZZHdgqYNIBxGjMvwOj8XuwDPCA7x+LL2qUsRO6EdRO3o7iKOS4AYccpgQ==", null, false, "d2f94509-b6a8-4ce4-80fd-c39c6fbd7c9f", false, "Participant2" });

            migrationBuilder.InsertData(
                table: "KeyPoints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Malyovitsa Hut" },
                    { 2, "Vihren Hut" },
                    { 3, "Popovo Lake" },
                    { 4, "Kazanite" },
                    { 5, "Koncheto Shelter" },
                    { 6, "Koncheto" },
                    { 7, "Vidimsko Praskalo Waterfall" },
                    { 8, "Yastrebets lift station" },
                    { 9, "Yontchevo Lake" },
                    { 10, "Elenino Lake" }
                });

            migrationBuilder.UpdateData(
                table: "PersonalLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Favourite");

            migrationBuilder.InsertData(
                table: "TourPersonalLists",
                columns: new[] { "PersonalListId", "TourId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "ActivityType", "Description", "DestinationId", "Difficulty", "Duration", "ElevationGain", "Length", "MeetingPoint", "MeetingTime", "Name", "OrganiserId", "RouteType" },
                values: new object[] { 2, 1, "Very scenic and beautiful hiking. Dramatic cliffs, lakes and stunning views from the summit. Big part of the trail is very rocky so use stable hiking shoes. It’s physically demanding but an amaizing one. There is lots of water so no need to bring extra.", 2, 3, "About 7 hours inlucding breaks for pictures and a lunch break", 1017, 15.9, "Malyovitsa hotel", new DateTime(2024, 7, 25, 7, 0, 0, 0, DateTimeKind.Unspecified), "Malyovitsa Peak", "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b", 2 });

            migrationBuilder.InsertData(
                table: "FeedBacks",
                columns: new[] { "Id", "ActivityType", "AuthorId", "CreatedOn", "ModifiedOn", "Rate", "Review", "TourId" },
                values: new object[,]
                {
                    { 1, 1, "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b", new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Amazing trail. It had snowed the day before and it looked like a winter wonderland. Towards the end, follow the other mountaineers and don’t follow the all trails route. That being said, I didn’t have any snow spikes and the descent was SCARY. Managed to pull through. I even lost my phone on the trial, luckily I had my burner phone with my Bulgarian sim, which is why this journey starts halfway through. Anyway, it is so worth it. Get ready for an adventure almost 9,000 feet up in the Bulgarian mountains", 2 },
                    { 2, 4, "480fd4fe-3c32-4626-8ea9-ada588d0d24f", new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "", 2 }
                });

            migrationBuilder.InsertData(
                table: "TourFeatures",
                columns: new[] { "FeatureId", "TourId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 3, 2 },
                    { 14, 2 }
                });

            migrationBuilder.InsertData(
                table: "TourKeyPoints",
                columns: new[] { "KeyPointId", "TourId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "TourParticipants",
                columns: new[] { "ParticipantId", "TourId" },
                values: new object[] { "aec4bd2b-913c-425a-936f-8d2bd83c1164", 2 });

            migrationBuilder.InsertData(
                table: "TourPersonalLists",
                columns: new[] { "PersonalListId", "TourId" },
                values: new object[] { 4, 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_AspNetUsers_AuthorId",
                table: "FeedBacks",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_AspNetUsers_AuthorId",
                table: "FeedBacks");

            migrationBuilder.DeleteData(
                table: "FeedBacks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FeedBacks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TourFeatures",
                keyColumns: new[] { "FeatureId", "TourId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TourFeatures",
                keyColumns: new[] { "FeatureId", "TourId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "TourFeatures",
                keyColumns: new[] { "FeatureId", "TourId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "TourKeyPoints",
                keyColumns: new[] { "KeyPointId", "TourId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TourKeyPoints",
                keyColumns: new[] { "KeyPointId", "TourId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "TourParticipants",
                keyColumns: new[] { "ParticipantId", "TourId" },
                keyValues: new object[] { "aec4bd2b-913c-425a-936f-8d2bd83c1164", 2 });

            migrationBuilder.DeleteData(
                table: "TourPersonalLists",
                keyColumns: new[] { "PersonalListId", "TourId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TourPersonalLists",
                keyColumns: new[] { "PersonalListId", "TourId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f");

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KeyPoints",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "FeedBacks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBacks_AuthorId",
                table: "FeedBacks",
                newName: "IX_FeedBacks_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95f4c678-4f35-44bd-a77a-b806614facc1", "AQAAAAEAACcQAAAAEAGM0E9ueI4z/XbPsqDn9HuEgmYFc5i9ENuIJk+k5DVLa2RsleNBg6VzZSnk3KBPXg==", "f625baa6-44df-46ed-9d15-25516b1fd440" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3a54325f-11a7-430a-be6e-4fd31ff809d6", "participant@gmail.com", "PARTICIPANT@GMAIL.COM", "PARTICIPANT", "AQAAAAEAACcQAAAAEPCpgTNEYhoWXMhvneMjyI+62YS/U1tn8p7fGYSgGpk3oBWIkJ1K3Lcyl13qbCZuCw==", "7414b0d6-eb09-4705-b3fd-fbe5e57777a2", "Participant" });

            migrationBuilder.UpdateData(
                table: "PersonalLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Favourites");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_AspNetUsers_UserId",
                table: "FeedBacks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
