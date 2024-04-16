using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class AddIsDeletedColumnToDestinationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Destinations",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Destinations");

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
    }
}
