using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_HoaDonAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachHangId = table.Column<int>(type: "int", nullable: false),
                    TenHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaGiaoDich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_tbl_KhachHang_tbl_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiSanPhamId = table.Column<int>(type: "int", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaThan = table.Column<double>(type: "float", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KyHieuSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_SanPham_tbl_LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "SanPham_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonId = table.Column<int>(type: "int", nullable: true),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_tbl_HoaDon_tbl_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDon_tbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_tbl_KhachHang_tbl_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang_tbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_tbl_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_tbl_HoaDonId",
                table: "ChiTietHoaDon_tbl",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_tbl_KhachHangId",
                table: "ChiTietHoaDon_tbl",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_tbl_SanPhamId",
                table: "ChiTietHoaDon_tbl",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_tbl_KhachHangId",
                table: "HoaDon_tbl",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_LoaiSanPhamId",
                table: "SanPhams",
                column: "LoaiSanPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon_tbl");

            migrationBuilder.DropTable(
                name: "HoaDon_tbl");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhachHang_tbl");

            migrationBuilder.DropTable(
                name: "SanPham_tbl");
        }
    }
}
