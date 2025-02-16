using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vineyards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vineyards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    VineyardId = table.Column<int>(type: "int", nullable: false),
                    GrapeId = table.Column<int>(type: "int", nullable: false),
                    YearPlanted = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcels_Grapes_GrapeId",
                        column: x => x.GrapeId,
                        principalTable: "Grapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcels_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcels_Vineyards_VineyardId",
                        column: x => x.VineyardId,
                        principalTable: "Vineyards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Grapes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tempranillo" },
                    { 2, "Albariño" },
                    { 3, "Garnacha" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Name", "TaxNumber" },
                values: new object[,]
                {
                    { 1, "Miguel Torres", "132254524" },
                    { 2, "Ana Martín", "143618668" },
                    { 3, "Carlos Ruiz", "78903228" }
                });

            migrationBuilder.InsertData(
                table: "Vineyards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Viña Esmeralda" },
                    { 2, "Bodegas Bilbaínas" }
                });

            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "Area", "GrapeId", "ManagerId", "VineyardId", "YearPlanted" },
                values: new object[,]
                {
                    { 1, 1500, 1, 1, 1, 2019 },
                    { 2, 9000, 2, 2, 2, 2021 },
                    { 3, 3000, 3, 3, 1, 2020 },
                    { 4, 2000, 1, 1, 2, 2020 },
                    { 5, 1000, 3, 3, 2, 2021 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_GrapeId",
                table: "Parcels",
                column: "GrapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ManagerId",
                table: "Parcels",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_VineyardId",
                table: "Parcels",
                column: "VineyardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "Grapes");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Vineyards");
        }
    }
}
