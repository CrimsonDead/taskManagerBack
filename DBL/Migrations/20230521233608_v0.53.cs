using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBL.Migrations
{
    public partial class v053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f0a04ce-ce6b-4439-8f87-1b1dbf3249a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "925bc42e-37a4-43df-ab36-f544f8fa0ccb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8024814-d7e6-4965-81db-52cd7ada67e7");

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: "d2804b2c-fc4c-452d-b88c-eb78e078a5e5");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: "002a91d5-cf94-4ca8-a672-bcb4c0783205");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3b16f6f-2e80-4830-9c6a-6ccddd4fdba7", "6307cc13-1043-401e-b72c-bffcd1fb32d1", "User", "USER" },
                    { "d2d0de3c-df30-438c-879f-bbed608c15d5", "d349ab2e-33fa-4199-951b-407b049f3d2c", "Manager", "MANAGER" },
                    { "d98afe98-f4f2-43b3-8a26-82e7793f7712", "a764ba07-4194-46f9-bf24-b9083d1f45b8", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12ffd34e-919b-41d6-a91a-260f1d0787b1", 0, "1cac67c8-c302-4825-9110-a0de223ff9a1", "Amin@a.min", true, false, null, null, null, null, "123", false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Description", "Title" },
                values: new object[] { "7dddd100-3eb9-4a0e-b9e8-b72e7fbf51fe", "Shadow fiend ", "ZXC lobby" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d98afe98-f4f2-43b3-8a26-82e7793f7712", "12ffd34e-919b-41d6-a91a-260f1d0787b1" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "EndDate", "EstimetedTime", "JobRefId", "ParentJobJobId", "Progress", "ProjectRefId", "SpentTime", "StartDate", "Status", "Title" },
                values: new object[] { "343e611f-7e5f-4a17-a963-5d2fd1539994", "Pick Shadow Fiend as your opponent", new DateTime(2023, 5, 22, 7, 36, 7, 248, DateTimeKind.Local).AddTicks(9300), 3.5, null, null, 0, "7dddd100-3eb9-4a0e-b9e8-b72e7fbf51fe", null, new DateTime(2023, 5, 22, 2, 36, 7, 248, DateTimeKind.Local).AddTicks(9272), 0, "Pick Shadow Fiend" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b16f6f-2e80-4830-9c6a-6ccddd4fdba7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2d0de3c-df30-438c-879f-bbed608c15d5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d98afe98-f4f2-43b3-8a26-82e7793f7712", "12ffd34e-919b-41d6-a91a-260f1d0787b1" });

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: "343e611f-7e5f-4a17-a963-5d2fd1539994");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d98afe98-f4f2-43b3-8a26-82e7793f7712");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12ffd34e-919b-41d6-a91a-260f1d0787b1");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: "7dddd100-3eb9-4a0e-b9e8-b72e7fbf51fe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f0a04ce-ce6b-4439-8f87-1b1dbf3249a8", "dc8c061b-2ce7-43a0-9f5d-e1c3bb0d4b2c", "User", "USER" },
                    { "925bc42e-37a4-43df-ab36-f544f8fa0ccb", "657668ea-f941-440f-ac9e-8f7f5b1c5923", "Manager", "MANAGER" },
                    { "c8024814-d7e6-4965-81db-52cd7ada67e7", "ef3ab250-08f7-41f8-98ac-b420ffb27027", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Description", "Title" },
                values: new object[] { "002a91d5-cf94-4ca8-a672-bcb4c0783205", "Shadow fiend ", "ZXC lobby" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "EndDate", "EstimetedTime", "JobRefId", "ParentJobJobId", "Progress", "ProjectRefId", "SpentTime", "StartDate", "Status", "Title" },
                values: new object[] { "d2804b2c-fc4c-452d-b88c-eb78e078a5e5", "Pick Shadow Fiend as your opponent", new DateTime(2023, 5, 20, 3, 27, 30, 735, DateTimeKind.Local).AddTicks(9097), 3.5, null, null, 0, "002a91d5-cf94-4ca8-a672-bcb4c0783205", null, new DateTime(2023, 5, 19, 22, 27, 30, 735, DateTimeKind.Local).AddTicks(9072), 0, "Pick Shadow Fiend" });
        }
    }
}
