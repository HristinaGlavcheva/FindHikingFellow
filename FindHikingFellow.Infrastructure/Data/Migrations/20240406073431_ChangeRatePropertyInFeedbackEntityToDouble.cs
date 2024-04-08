using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class ChangeRatePropertyInFeedbackEntityToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "FeedBacks",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.UpdateData(
                table: "FeedBacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rate",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "FeedBacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rate",
                value: 5.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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

            migrationBuilder.UpdateData(
                table: "FeedBacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rate",
                value: 5);

            migrationBuilder.UpdateData(
                table: "FeedBacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rate",
                value: 5);
        }
    }
}
