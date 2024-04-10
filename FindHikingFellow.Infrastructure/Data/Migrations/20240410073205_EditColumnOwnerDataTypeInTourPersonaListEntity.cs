using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class EditColumnOwnerDataTypeInTourPersonaListEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "TourPersonalLists");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "TourPersonalLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d534bcd3-e6f5-4f46-adc5-eab46091f5c1", "AQAAAAEAACcQAAAAEGc+GEY0Uth6CEqQm/4t8hLd9IzInlnjSwhCr5l6btmR1ZowKz0eI0ySbTpku2Gq3Q==", "6814050f-122b-4ba5-98ca-1ddc0cd79f4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33a97044-798e-47fc-8085-aaee5382c099", "AQAAAAEAACcQAAAAEHox8EA6WVcuyUbuh7nQH1MIfwrpfanaCfwrGWBSj9CRttIZz0j3ng7KF3whfB4eAA==", "97808364-660c-4235-b217-e12e8500fa3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7955863d-fd84-4fcd-a6ea-c8499a549b56", "AQAAAAEAACcQAAAAEO5ebDmjTv5klznZjoMbCsBxVhStrPmvrk75sUeWSi9rwIg54PhDfGMgE+9mzB8phQ==", "63fa8168-7d06-48ba-b511-a2701888ab76" });

            migrationBuilder.CreateIndex(
                name: "IX_TourPersonalLists_OwnerId",
                table: "TourPersonalLists",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPersonalLists_AspNetUsers_OwnerId",
                table: "TourPersonalLists",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPersonalLists_AspNetUsers_OwnerId",
                table: "TourPersonalLists");

            migrationBuilder.DropIndex(
                name: "IX_TourPersonalLists_OwnerId",
                table: "TourPersonalLists");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "TourPersonalLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "TourPersonalLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "357c476c-8c98-4a86-bce5-78c9303d8efb", "AQAAAAEAACcQAAAAEFtnfKdkjYytZcCbsyFSdRRYoCkIYZd7eqMS9g6UGmiyOvTEO+22wa4zClPilcEp8A==", "96b55108-4f28-490e-9230-567a6ad2d3ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f26d0aa9-78c7-483c-8d9f-9cfd6c786a3d", "AQAAAAEAACcQAAAAEDmFOx3DY3Hl3X8VfrOw3S11B8gC/L3t3uRXjLlUVTzBj1egmBf4COKJfxMV8LYcYg==", "9b297d55-fdba-4797-b4ca-bd636b5c70c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69903ccd-1774-4d58-bda1-8d7ba1ce9d00", "AQAAAAEAACcQAAAAEMd3NV+l7jO5Igj8N1bK18nZXlG6fSQoCXJt4x9xhV2GEULZUyH+PBc+3gKCaLkFBA==", "ad74f9ef-4424-4c15-a04d-054dfc54ca09" });
        }
    }
}
