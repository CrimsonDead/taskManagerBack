using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBL.Migrations
{
    public partial class vo52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "227ed1b5-c9ea-4b76-8f70-5357c7fc15e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c15eaa6-42f9-4fb7-b5d8-ab7733840cc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d65b480f-b3f9-4f20-abaf-5c664091346a");

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: "a651a6b1-777d-4758-85a7-b3eca663c349");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: "d87b89a0-c344-4092-a51b-fd5e230d4670");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "227ed1b5-c9ea-4b76-8f70-5357c7fc15e1", "45df11e8-1cca-425d-b394-ade2a23aabfc", "User", null },
                    { "2c15eaa6-42f9-4fb7-b5d8-ab7733840cc9", "a5595b47-8575-478a-b7a1-af86a052a4db", "Admin", null },
                    { "d65b480f-b3f9-4f20-abaf-5c664091346a", "3ac47306-639a-4bdf-a10c-94b4c6ca390b", "Manager", null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Description", "Title" },
                values: new object[] { "d87b89a0-c344-4092-a51b-fd5e230d4670", "Shadow fiend ", "ZXC lobby" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "EndDate", "EstimetedTime", "JobRefId", "ParentJobJobId", "Progress", "ProjectRefId", "SpentTime", "StartDate", "Status", "Title" },
                values: new object[] { "a651a6b1-777d-4758-85a7-b3eca663c349", "Pick Shadow Fiend as your opponent", new DateTime(2023, 5, 19, 6, 56, 29, 339, DateTimeKind.Local).AddTicks(3826), 3.5, null, null, 0, "d87b89a0-c344-4092-a51b-fd5e230d4670", null, new DateTime(2023, 5, 19, 1, 56, 29, 339, DateTimeKind.Local).AddTicks(3803), 0, "Pick Shadow Fiend" });
        }
    }
}
