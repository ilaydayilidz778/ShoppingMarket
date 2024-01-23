using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcSupreMarketCrudveResimEkleme.Migrations
{
    /// <inheritdoc />
    public partial class Ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StotkataMi = table.Column<bool>(type: "bit", nullable: false),
                    StokMiktari = table.Column<int>(type: "int", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SatistanKaldirilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urunler_kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosyaYolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resimler_urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "kategoriler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Su & İçecek" },
                    { 2, "Meyve & Sebze" },
                    { 3, "Süt Ürünleri" },
                    { 4, "Atıştırmalık" },
                    { 5, "Temel Gıda" },
                    { 6, "Kahvaltılık" },
                    { 7, "Fırından" },
                    { 8, "Kişisel Bakım" },
                    { 9, "Evcil Hayvan" },
                    { 10, "Ev Bakım" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_resimler_UrunId",
                table: "resimler",
                column: "UrunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_urunler_KategoriId",
                table: "urunler",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resimler");

            migrationBuilder.DropTable(
                name: "urunler");

            migrationBuilder.DropTable(
                name: "kategoriler");
        }
    }
}
