using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBL.Migrations
{
    /// <inheritdoc />
    public partial class v031 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Jobs_SubJobJobId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "087baccb-b4e8-48eb-a956-926c37d91d38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63875343-d75a-49f7-8e29-8eb28f8c8716");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a99ce00e-06d5-4912-91fc-d9771add9154");

            migrationBuilder.RenameColumn(
                name: "SubJobJobId",
                table: "Jobs",
                newName: "ParentJobJobId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_SubJobJobId",
                table: "Jobs",
                newName: "IX_Jobs_ParentJobJobId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2abb2c23-8af8-49ea-89b5-d1b9a186db18", "0e84cc24-aece-421d-9855-3df359e2b08b", "UserRoleModel", "Admin", null },
                    { "c4556595-421a-4a90-8892-ee8d63ce88c0", "9b75f8b2-4294-4182-bf69-1beccebb8368", "UserRoleModel", "Manager", null },
                    { "eaec9fb6-b502-462c-b6ad-0add54c461bf", "40d709ee-2aef-4693-a135-71d29b975866", "UserRoleModel", "User", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Jobs_ParentJobJobId",
                table: "Jobs",
                column: "ParentJobJobId",
                principalTable: "Jobs",
                principalColumn: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Jobs_ParentJobJobId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2abb2c23-8af8-49ea-89b5-d1b9a186db18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4556595-421a-4a90-8892-ee8d63ce88c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaec9fb6-b502-462c-b6ad-0add54c461bf");

            migrationBuilder.RenameColumn(
                name: "ParentJobJobId",
                table: "Jobs",
                newName: "SubJobJobId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_ParentJobJobId",
                table: "Jobs",
                newName: "IX_Jobs_SubJobJobId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "087baccb-b4e8-48eb-a956-926c37d91d38", "37705e90-f8f9-4fdb-baaa-45f029697050", "UserRoleModel", "User", null },
                    { "63875343-d75a-49f7-8e29-8eb28f8c8716", "f1f168cd-4656-4c22-bb9f-b871ab3cb8e8", "UserRoleModel", "Admin", null },
                    { "a99ce00e-06d5-4912-91fc-d9771add9154", "9cbfbe94-88e8-449a-a22f-e13ac577135b", "UserRoleModel", "Manager", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Jobs_SubJobJobId",
                table: "Jobs",
                column: "SubJobJobId",
                principalTable: "Jobs",
                principalColumn: "JobId");
        }
    }
}
