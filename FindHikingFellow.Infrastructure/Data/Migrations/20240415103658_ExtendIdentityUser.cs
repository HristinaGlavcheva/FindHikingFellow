using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class ExtendIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9cb58b88-6913-4f0d-8d43-bd880cad9c5e", "", "", "PARTICIPANT2@GMAIL.COM", "AQAAAAEAACcQAAAAEFib6/rXTFlA7gix0niF71qeBQPGmwJMA9zq3Mh9KkvpqRJoXk3BuvKP6LBM8OQhBQ==", "8297f971-cf3f-46f9-9782-a42cec022560", "participant2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f0723dfb-e8ee-44d1-8254-b830bb334d5c", "ORGANISER@GMAIL.COM", "", "", "AQAAAAEAACcQAAAAEAN4NRAj/TIA6zI43FICsvPV8K0Rjy9kSBZAjIXmTFyJOrO0ElPQv3tmfsY2C7f6qA==", "68f3ba9d-dc3a-4901-9790-0fa54e7a3b42", "organiser@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b4198e36-6936-4a56-9393-fd9439ba83b8", "", "", "PARTICIPANT1@GMAIL.COM", "AQAAAAEAACcQAAAAEJrJ1mJJIE2lANFyvhCgVKLLowDVLbQrTZY/J7akaABnjvCMzz7tZ/r9LTwrXhh7Bg==", "7ba90cdb-baac-432e-84b5-5c9278b6d481", "participant1@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d534bcd3-e6f5-4f46-adc5-eab46091f5c1", "PARTICIPANT2", "AQAAAAEAACcQAAAAEGc+GEY0Uth6CEqQm/4t8hLd9IzInlnjSwhCr5l6btmR1ZowKz0eI0ySbTpku2Gq3Q==", "6814050f-122b-4ba5-98ca-1ddc0cd79f4f", "Participant2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "33a97044-798e-47fc-8085-aaee5382c099", "organiser@gmail.com", "AQAAAAEAACcQAAAAEHox8EA6WVcuyUbuh7nQH1MIfwrpfanaCfwrGWBSj9CRttIZz0j3ng7KF3whfB4eAA==", "97808364-660c-4235-b217-e12e8500fa3b", "Organiser" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7955863d-fd84-4fcd-a6ea-c8499a549b56", "PARTICIPANT1", "AQAAAAEAACcQAAAAEO5ebDmjTv5klznZjoMbCsBxVhStrPmvrk75sUeWSi9rwIg54PhDfGMgE+9mzB8phQ==", "63fa8168-7d06-48ba-b511-a2701888ab76", "Participant1" });
        }
    }
}
