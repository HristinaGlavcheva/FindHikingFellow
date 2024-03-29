using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class AddColumnImageUrlToToursTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Tours",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "103126d5-96b7-4eaa-b6b8-a94e7923c268", "AQAAAAEAACcQAAAAEAnCisZ2cyFObxrRryjqz+RTi4g9VRustjeDhqUy2NB1VJnsPgt5KHeLvIJGklCMZg==", "4c2a5d7a-9e81-4551-8c58-dcf90eafa567" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05054413-2ae4-4d56-aca7-527fbf5f011a", "AQAAAAEAACcQAAAAENYcadW0ZS0lJ2MoyCDLsxdRAIjxsyuz9Lui/4K1XXGo2WdamwLL3TYkdhFN+5L82A==", "82126728-456a-408c-a586-2e3299008d6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "064cff0d-0410-463d-9d3d-458d06cfe169", "AQAAAAEAACcQAAAAEDDWnWcJOKJiZn9UDBB5R+Urqz0NYeYkSj4iXOrb4rcmEK8/8A0PASUiZSYcw4T+jg==", "451489f8-a240-4b12-9958-bcfb04ecfd15" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://vedri.bg/media/fufl535h/national-park-rila-bulgaria.jpg");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.datocms-assets.com/55179/1647278287-screen-shot-2019-07-22-at-7-13-00-am.png");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://novavarna.net/wp-content/uploads/2020/06/rila_maliovica-1280x720.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Tours");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbc3d347-b288-4884-a238-d0319d0bcc8c", "AQAAAAEAACcQAAAAELw0JctKPF63vqcferh8XN7navTfzNZLn8FPlS8xd+r2s0hcXVNQ9JsHfhjyn3mlMA==", "08c9335b-0321-4e90-ac1c-7b0a2896cd77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9faba8e-dca3-4067-a13d-250524bcced6", "AQAAAAEAACcQAAAAEGOFjxuLHz6LgYgRyrt4c+hlS5IMPBBBt34Q5/DYmfFE6t8p0JOzZ3Ds/tT2y9wX+g==", "32433bc1-42c5-4a83-8772-5e3ae06afcfc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "deb18534-deb0-4ea1-ba4c-6b17c5a5b0c2", "AQAAAAEAACcQAAAAEBcGg2dNVIkbML22fporDE1MC/6TD87Ctxcg84awi04OKOmCGpcYlF0D8ct2jl8GaA==", "70ad3b52-a0ea-4b9e-bee7-85fbcc6dc2fa" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://novavarna.net/wp-content/uploads/2020/06/rila_maliovica-1280x720.jpg");
        }
    }
}
