using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class AddIsApprovedPropertyToHouseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Tours",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is tour approved by admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e428881f-93a6-42f2-a462-82f008125fa6", "AQAAAAEAACcQAAAAEBXfr2aSqPMJzI8/qNif5qBQa9yM99sKc0Nth6ONf/Y1QkLWhQNWCn25u60M+pmeXg==", "c4ddfa1e-f083-435c-9ab5-e78d1e6fa4a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "164d1322-cc35-4dca-b4e2-ad2191810b6d", "AQAAAAEAACcQAAAAEKogwbbKCG+TsOBcAnpUw+oqg8sxvEn5eWUUO9lQ2x7PjEaDKHZKPAa0UenEeXs4Pw==", "8a6a475d-49f5-4db9-85a1-6b8993d7a257" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6726699e-e313-4535-a017-dd0d788b1c23", "AQAAAAEAACcQAAAAEONSjDO+aSB0ad4Ygh5I4yuKipDyd5ZgxD36nBUve8L3Q9v5j+zTEO67XdoRFwcNJg==", "ad0d9358-b282-435b-b69e-e6f6150d7d0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32f7ee52-fd3f-42b5-bf55-d94a3d19936e", "AQAAAAEAACcQAAAAEGJ8ZDKAruFZC9pg7g+goWasjnTP7r+WWpAiCZlDPAzHEGtkOq8tlMsNxoZZtMFY/w==", "a5e4b6e9-ca92-4a71-8c98-2dbe12989004" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Tours");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a81ae43-823d-48ab-bb5a-523829337cd8", "AQAAAAEAACcQAAAAEKjydb5CFqRfNGKvsVYru0ISD/OCpIORsNRm6HADiDsxPU7JNmMqglj3CmTvWBFo3w==", "da341f73-da29-4f71-b8c9-193f338b06a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06a3c994-0622-4e1e-83f4-b7dac94277f5", "AQAAAAEAACcQAAAAEGM8IaEIaxBgKCVjnXVyT8ntl2XurQQIZCgrok8YiL/K+G8vhLsU1Ar2GUch+KwIzg==", "8b64a52b-f64a-4e93-9d32-507511ae1e54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61f95fad-7f42-44ff-a2e7-e805ab5472c2", "AQAAAAEAACcQAAAAEJFgq3Hp2MUncPFHBsv1q43+90ymkcuGWxCPDWofb9SE/qbYfKyeuscRAi1KQxRhjQ==", "3b7bb6ea-1534-48a5-a6a8-57aa735ca94b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d2a82ce-1e6a-443c-897e-499ace2e4fb6", "AQAAAAEAACcQAAAAEI3HKaPc6mHqiV87YEJincDLukL5X7QV4ohXRchhSW2NAgPgqjVKOSHUsPX3qqazaA==", "074d7fab-bae6-4283-a94b-86a85e1ab905" });
        }
    }
}
