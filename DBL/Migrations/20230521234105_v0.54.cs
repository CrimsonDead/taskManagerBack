using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBL.Migrations
{
    public partial class v054 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "02a8e10c-6696-4354-a33e-c616d4435914", "67188ac7-a4de-4463-8e22-8348f1510c39", "User", "USER" },
                    { "500fbbf9-c8b4-4eb7-842c-a173e54c160d", "0c5248b5-bb83-4c6a-92af-9be9ed384245", "Admin", "ADMIN" },
                    { "6c1edc2e-d5fc-4eb6-b78a-c908e249db34", "883e1568-eed7-41c4-bbcf-91e8353f78cb", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4eafad46-6245-4306-95fe-1c5c22c8611f", 0, "fa5de024-a522-478d-8797-34d48fd5d097", "Amin@a.min", true, false, null, null, null, null, "123", false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Description", "Title" },
                values: new object[] { "d85a36b9-a446-4eda-aecc-38b43dd0577d", "Shadow fiend ", "Вырубка леса в секторе 8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "500fbbf9-c8b4-4eb7-842c-a173e54c160d", "4eafad46-6245-4306-95fe-1c5c22c8611f" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "EndDate", "EstimetedTime", "JobRefId", "ParentJobJobId", "Progress", "ProjectRefId", "SpentTime", "StartDate", "Status", "Title" },
                values: new object[] { "2015a16e-2985-4155-9981-53f2d01b3bc2", "Подготока транспорта и инструбемнов к вырубке", new DateTime(2023, 5, 22, 7, 41, 3, 912, DateTimeKind.Local).AddTicks(7797), 3.5, null, null, 0, "d85a36b9-a446-4eda-aecc-38b43dd0577d", null, new DateTime(2023, 5, 22, 2, 41, 3, 912, DateTimeKind.Local).AddTicks(7768), 0, "Подготовка оборудования" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "EndDate", "EstimetedTime", "JobRefId", "ParentJobJobId", "Progress", "ProjectRefId", "SpentTime", "StartDate", "Status", "Title" },
                values: new object[] { "5de1bb68-11c1-43ec-8375-8d9204bf82fe", "Вырубка", new DateTime(2023, 5, 22, 7, 41, 3, 912, DateTimeKind.Local).AddTicks(7824), 3.5, null, null, 0, "d85a36b9-a446-4eda-aecc-38b43dd0577d", null, new DateTime(2023, 5, 22, 2, 41, 3, 912, DateTimeKind.Local).AddTicks(7823), 0, "Вырубка" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02a8e10c-6696-4354-a33e-c616d4435914");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c1edc2e-d5fc-4eb6-b78a-c908e249db34");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "500fbbf9-c8b4-4eb7-842c-a173e54c160d", "4eafad46-6245-4306-95fe-1c5c22c8611f" });

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: "2015a16e-2985-4155-9981-53f2d01b3bc2");

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: "5de1bb68-11c1-43ec-8375-8d9204bf82fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "500fbbf9-c8b4-4eb7-842c-a173e54c160d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4eafad46-6245-4306-95fe-1c5c22c8611f");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: "d85a36b9-a446-4eda-aecc-38b43dd0577d");

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
    }
}
