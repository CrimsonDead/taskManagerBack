using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBL.Migrations
{
    /// <inheritdoc />
    public partial class v021 : Migration
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
                keyValue: "009d5cd9-f6b2-44ab-8e9d-02e8d50d8483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "317035be-99f5-4ed2-a1a9-81fdb4104180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcbf87e9-c9c0-4e57-87ca-d86fa80b58b1");

            migrationBuilder.AlterColumn<string>(
                name: "SubJobJobId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1225949d-3d56-4a1e-9545-4dac3fda0eef", "88d110ce-f611-467b-a57e-49cf8b1e7685", "UserRoleModel", "User", null },
                    { "8789703c-cbc7-4f2f-999d-a2e5fc399d32", "e54cf4fe-90ab-4183-9b1e-da09e1f54ccb", "UserRoleModel", "Admin", null },
                    { "eda6a8e9-94cb-4897-9fa0-8da7a0dc7eba", "8fc915e9-0f64-44d6-9c2c-632993346b57", "UserRoleModel", "Manager", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Jobs_SubJobJobId",
                table: "Jobs",
                column: "SubJobJobId",
                principalTable: "Jobs",
                principalColumn: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Jobs_SubJobJobId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1225949d-3d56-4a1e-9545-4dac3fda0eef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8789703c-cbc7-4f2f-999d-a2e5fc399d32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eda6a8e9-94cb-4897-9fa0-8da7a0dc7eba");

            migrationBuilder.AlterColumn<string>(
                name: "SubJobJobId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "009d5cd9-f6b2-44ab-8e9d-02e8d50d8483", "6cc3bb43-7406-47fc-9905-0862ac5e2033", "UserRoleModel", "Manager", null },
                    { "317035be-99f5-4ed2-a1a9-81fdb4104180", "7168d24f-36e9-4d15-8e0f-6007f42c7935", "UserRoleModel", "User", null },
                    { "fcbf87e9-c9c0-4e57-87ca-d86fa80b58b1", "4e883cd1-f475-4272-b03b-5bded871cfc9", "UserRoleModel", "Admin", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Jobs_SubJobJobId",
                table: "Jobs",
                column: "SubJobJobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
