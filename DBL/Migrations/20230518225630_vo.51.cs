using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBL.Migrations
{
    public partial class vo51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f164b83-f30e-471f-9939-a7fcae95caa0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ff88b2f-86e2-40a8-8879-15e276f0f29d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d51db1a7-e87e-4c75-957d-ce37b35cc66b");

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: "9ee0a1df-bdb2-4121-9b25-3ba0c555522c");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: "feeef8af-1e4f-4234-827a-bd92e601819b");

            migrationBuilder.DropColumn(
                name: "pts",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Pts",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Progress",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "pts",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Progress",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Pts",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f164b83-f30e-471f-9939-a7fcae95caa0", "568631c8-daae-4e09-9550-196ce19bd7b5", "Admin", null },
                    { "8ff88b2f-86e2-40a8-8879-15e276f0f29d", "1ae8fbda-e034-4262-904c-b0c2df81be69", "Manager", null },
                    { "d51db1a7-e87e-4c75-957d-ce37b35cc66b", "bd6582ba-438b-4cf3-87d9-cbef394ea778", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Description", "Title", "pts" },
                values: new object[] { "feeef8af-1e4f-4234-827a-bd92e601819b", "Shadow fiend ", "ZXC lobby", 0 });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "EndDate", "EstimetedTime", "JobRefId", "ParentJobJobId", "Progress", "ProjectRefId", "SpentTime", "StartDate", "Status", "Title" },
                values: new object[] { "9ee0a1df-bdb2-4121-9b25-3ba0c555522c", "Pick Shadow Fiend as your opponent", new DateTime(2023, 5, 19, 1, 42, 22, 107, DateTimeKind.Local).AddTicks(3588), 3.5, null, null, null, "feeef8af-1e4f-4234-827a-bd92e601819b", null, new DateTime(2023, 5, 18, 20, 42, 22, 107, DateTimeKind.Local).AddTicks(3563), 0, "Pick Shadow Fiend" });
        }
    }
}
