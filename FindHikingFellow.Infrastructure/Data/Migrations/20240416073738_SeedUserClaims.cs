using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class SeedUserClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Organiser First", "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b" },
                    { 2, "user:fullname", "Admin First", "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d" },
                    { 3, "user:fullname", "Participant First", "aec4bd2b-913c-425a-936f-8d2bd83c1164" },
                    { 4, "user:fullname", "Participant Second", "480fd4fe-3c32-4626-8ea9-ada588d0d24f" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f813c56b-8730-4f46-98c2-46a8f4aa0562", "AQAAAAEAACcQAAAAEBJXYGl4wpZ1qLZkTXWBdQ9/yya7EwVelarE4x28DRT2WuA4wn0DuYrzjGeK1qbs+w==", "92e06bf5-0e72-40a1-9e9b-f7ed86c18f10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd24e4dd-38ec-465b-84cf-df995e0dfb26", "AQAAAAEAACcQAAAAEND9LwqWf+QrTACyqEm+2IpCUy5/kI8eTnRE26cymVprGtRosK7okZ9aZ3RDtcwxcQ==", "f2e84055-6ea2-4778-b6fa-726d2894c19e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "618c1d46-5952-4688-977f-97ec41331021", "AQAAAAEAACcQAAAAEOIp7pF1jheaznz4Rj4YRCN5sq1hM4YgbtRLyXlA0FV2oTitv+OxAhL+xGNjKrQdYQ==", "66cbf4b3-f0ea-42e2-8f45-c2764c38d11f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e2f0edf-9de9-4dcf-9620-96fc462e0122", "AQAAAAEAACcQAAAAEDL/zPu7ViAhQgzdPwH5dEVrEta45Ah+OF4iY6oZ4kfJmzzX7njgQZdX9E7FMKazgg==", "bbbc31da-9972-4e83-9017-a77b3f01d662" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

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
    }
}
