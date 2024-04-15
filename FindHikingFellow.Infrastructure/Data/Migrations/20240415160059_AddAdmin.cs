using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHikingFellow.Data.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a81ae43-823d-48ab-bb5a-523829337cd8", "Participant", "Second", "AQAAAAEAACcQAAAAEKjydb5CFqRfNGKvsVYru0ISD/OCpIORsNRm6HADiDsxPU7JNmMqglj3CmTvWBFo3w==", "da341f73-da29-4f71-b8c9-193f338b06a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61f95fad-7f42-44ff-a2e7-e805ab5472c2", "organiser@gmail.com", "Organiser", "First", "AQAAAAEAACcQAAAAEJFgq3Hp2MUncPFHBsv1q43+90ymkcuGWxCPDWofb9SE/qbYfKyeuscRAi1KQxRhjQ==", "3b7bb6ea-1534-48a5-a6a8-57aa735ca94b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d2a82ce-1e6a-443c-897e-499ace2e4fb6", "Participant", "First", "AQAAAAEAACcQAAAAEI3HKaPc6mHqiV87YEJincDLukL5X7QV4ohXRchhSW2NAgPgqjVKOSHUsPX3qqazaA==", "074d7fab-bae6-4283-a94b-86a85e1ab905" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d", 0, "06a3c994-0622-4e1e-83f4-b7dac94277f5", "admin@gmail.com", false, "Admin", "First", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGM8IaEIaxBgKCVjnXVyT8ntl2XurQQIZCgrok8YiL/K+G8vhLsU1Ar2GUch+KwIzg==", null, false, "8b64a52b-f64a-4e93-9d32-507511ae1e54", false, "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "188cf0ae-fb29-49b7-967a-b7481103499b", "", "", "AQAAAAEAACcQAAAAEJiUiZnX0+BG6qxfzBoY7N5BeZGy07POSfDny/ub8OxUCJSeEmX4aWUZZ58VGPK1aQ==", "0c6b47ac-79cd-4a38-bd4b-421c5480235f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c83fc19c-86ff-43f7-a2a5-b07e92a00df7", "ORGANISER@GMAIL.COM", "", "", "AQAAAAEAACcQAAAAEHiUHNOAT9krHgd9FBSz51Ul8eHTo3GAa6XnbvXYGIodzEuuqsR5cimHqPve+wpnfw==", "43408834-5809-4e65-a488-752980f92994" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc89b03-f77b-49f6-a3a7-5aff81a2d93c", "", "", "AQAAAAEAACcQAAAAEGmR+7N8A+vc117EkeRDitlIULMXIYFzwMb+9SvdGbHcS1zu1AsDvYNp4jBDFp6ACA==", "13df023c-63e0-47ba-8f9f-d6e1764f9c7d" });
        }
    }
}
