using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class RemoveUnusedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "TourFeatures");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ec9e82c-3e9c-4545-85a8-4aa2546e8de3", "AQAAAAEAACcQAAAAEN0mfZ83tNLpKMceA+HUx1RwteakckoWm/dGFI0xMz8qsqBE8Tpgd+9gLH0Cd9fh8w==", "08e60c0c-3af8-4a3b-842f-14ae5a0f22e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30de9f81-4b1d-4e75-99be-ce79c62bcc68", "AQAAAAEAACcQAAAAELW4924WerO5gyD4V/3QCt5Khv/7rhuQwyLpx9mml5LjjqTRByBz4qX6uW5JiAMW9w==", "4e7fe724-3512-41f6-b8c5-ae914f4cc564" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd6e608f-2d9b-4517-ae14-5405f550d2df", "AQAAAAEAACcQAAAAEJ7ho+lQtlHt9la12Io8dU0j1rER8bfUe6o47mATaKHPPNggCDECqqWTKdmgKNq4IA==", "2cda8ed1-782e-408b-8a65-57ec82493feb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dccab79-4f6a-459c-8b33-a66ac4174e52", "AQAAAAEAACcQAAAAEFEb28zfYDLofx37DMBpVvyKSn1umZ6crB48b/AeQnzN+V8JaEekSt4xh9Fv59Zsyg==", "139119a5-d63d-4ab9-b00d-b267b67a2092" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                },
                comment: "Additional distinctive feature of the tour");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Extension of the image file")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourFeatures",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourFeatures", x => new { x.TourId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_TourFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourFeatures_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2ce686e-ff32-485c-b249-2a08ab6b5fd0", "AQAAAAEAACcQAAAAEB++F6ygwMjsAC7N4zj/zTS/dDFLnFb9jY/wHVbBaziBUjigS/2Marpvm9OJc4DpvQ==", "80bfa5db-29f1-4794-82df-16ee93b94a23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bfe69db-b335-44cc-96bc-ebf8f40903b8", "AQAAAAEAACcQAAAAEGa++ARiefLT/yhATwPvoZSP0Ezr1+JgLr9a71KzjvDMmcUa7Oid4lYogXGvAkErLg==", "1ede89ba-3b3e-4e8e-bd1b-80c67079a77e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5594ddc-1af2-488e-a3fb-85231e5aadd5", "AQAAAAEAACcQAAAAEEPFlRNsmlFSSNWow8q99EuUpgBatvB/H3wkRTkrMCaXzHU0RFzhZI3OiTGVuGQU8w==", "d9e4ee85-19dc-4808-8809-2fefad9087d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afc55744-da8e-4170-a466-991b7d48fa6a", "AQAAAAEAACcQAAAAEN6ONd7w46hstuhaVMLRWONluIgabkz0RF5zCpShKJXHXu5P4Tux6I+5YdRIfWJ0Xw==", "154587c2-c3d8-492b-bbfc-e1af13d415fe" });

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
                table: "TourFeatures",
                columns: new[] { "FeatureId", "TourId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "TourFeatures",
                columns: new[] { "FeatureId", "TourId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "TourFeatures",
                columns: new[] { "FeatureId", "TourId" },
                values: new object[] { 14, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Images_AddedByUserId",
                table: "Images",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TourId",
                table: "Images",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourFeatures_FeatureId",
                table: "TourFeatures",
                column: "FeatureId");
        }
    }
}
