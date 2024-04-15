using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class ExtendIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "188cf0ae-fb29-49b7-967a-b7481103499b", "AQAAAAEAACcQAAAAEJiUiZnX0+BG6qxfzBoY7N5BeZGy07POSfDny/ub8OxUCJSeEmX4aWUZZ58VGPK1aQ==", "0c6b47ac-79cd-4a38-bd4b-421c5480235f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c83fc19c-86ff-43f7-a2a5-b07e92a00df7", "ORGANISER@GMAIL.COM", "AQAAAAEAACcQAAAAEHiUHNOAT9krHgd9FBSz51Ul8eHTo3GAa6XnbvXYGIodzEuuqsR5cimHqPve+wpnfw==", "43408834-5809-4e65-a488-752980f92994" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc89b03-f77b-49f6-a3a7-5aff81a2d93c", "AQAAAAEAACcQAAAAEGmR+7N8A+vc117EkeRDitlIULMXIYFzwMb+9SvdGbHcS1zu1AsDvYNp4jBDFp6ACA==", "13df023c-63e0-47ba-8f9f-d6e1764f9c7d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb58b88-6913-4f0d-8d43-bd880cad9c5e", "AQAAAAEAACcQAAAAEFib6/rXTFlA7gix0niF71qeBQPGmwJMA9zq3Mh9KkvpqRJoXk3BuvKP6LBM8OQhBQ==", "8297f971-cf3f-46f9-9782-a42cec022560" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0723dfb-e8ee-44d1-8254-b830bb334d5c", "ORGANISER", "AQAAAAEAACcQAAAAEAN4NRAj/TIA6zI43FICsvPV8K0Rjy9kSBZAjIXmTFyJOrO0ElPQv3tmfsY2C7f6qA==", "68f3ba9d-dc3a-4901-9790-0fa54e7a3b42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4198e36-6936-4a56-9393-fd9439ba83b8", "AQAAAAEAACcQAAAAEJrJ1mJJIE2lANFyvhCgVKLLowDVLbQrTZY/J7akaABnjvCMzz7tZ/r9LTwrXhh7Bg==", "7ba90cdb-baac-432e-84b5-5c9278b6d481" });
        }
    }
}
