using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class AddColumnsOwnerAndOwnerIdToTourPersonalListTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TourPersonalLists",
                keyColumns: new[] { "PersonalListId", "TourId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TourPersonalLists",
                keyColumns: new[] { "PersonalListId", "TourId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "TourPersonalLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "TourPersonalLists");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "TourPersonalLists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db1ad637-e06d-456f-abb2-a9bfd56c5a83", "AQAAAAEAACcQAAAAEMPTwobsVL5xahEGHkAebA04sS+Dpt35H+NGz6M7Wxnhr/p0+57Bu1jyPlN7pMmBZQ==", "9103f362-8a9a-4cfe-8a0d-00a83661b7b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dd3d7e1-9804-4314-8fce-b6d596b295de", "AQAAAAEAACcQAAAAECMQr/qPmYeD99AfldBNKnJm4aGLhI5NtoEgAHMhQuJGxfwGqIZORaXakvIK9sXpAA==", "63651d49-2795-4ee6-abe4-972f0271fd63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "138e10ad-a31e-4aac-b43d-5bf20c705b09", "AQAAAAEAACcQAAAAEHMbl4IgEjTZ777gNCUz6Iau4vH2yL8ZxbzqrM5uvXFay4dTIbo5R8boEmTcfv54Xg==", "9565fd92-06ed-4937-b11d-ffe195b65d87" });

            migrationBuilder.InsertData(
                table: "TourPersonalLists",
                columns: new[] { "PersonalListId", "TourId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 }
                });
        }
    }
}
