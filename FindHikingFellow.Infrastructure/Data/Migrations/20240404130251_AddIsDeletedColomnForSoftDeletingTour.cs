using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class AddIsDeletedColomnForSoftDeletingTour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cff30ed8-a872-41c6-aa20-d3a134e1db2b", "AQAAAAEAACcQAAAAEFQDAau+3dgFNWVxzczem208xr667f8blkf8CTUKrMjdJUCAxqIpxBa+ZHSNmcVHWw==", "1ae4633f-8074-4b64-af46-b50b79a4116a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af9caef5-dc4e-4f5a-b5e6-0dd06757f53a", "AQAAAAEAACcQAAAAELjaOtVM0ibZMN1o12+MCGQMzGqTK1jtIv17+TlSc6z2LleLrPhF51pM8DMUWY1Yvg==", "4aa3fc51-e324-4df9-9c11-3ce405a71b92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a39ee87-0a90-4843-a3dc-b867c0649f1e", "AQAAAAEAACcQAAAAEAL6rIPnfVWEdCDestnzchsIwLGVWiXT+os8DxBCxhEa2IDd6d09Vc6KtVoeDP9mxA==", "9518744a-ba9c-43da-b2ca-eb9961a42736" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tours");

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
        }
    }
}
