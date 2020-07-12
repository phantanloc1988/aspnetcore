using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace buoi14.Migrations
{
    public partial class Add_Table_HangHoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_loais",
                table: "loais");

            migrationBuilder.RenameTable(
                name: "loais",
                newName: "Loai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loai",
                table: "Loai",
                column: "MaLoai");

            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    MaHH = table.Column<Guid>(nullable: false),
                    TenHH = table.Column<string>(maxLength: 50, nullable: false),
                    DonGia = table.Column<double>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    Hinh = table.Column<string>(nullable: true),
                    MaLoai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.MaHH);
                    table.ForeignKey(
                        name: "FK_HangHoas_Loai_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoas",
                column: "MaLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loai",
                table: "Loai");

            migrationBuilder.RenameTable(
                name: "Loai",
                newName: "loais");

            migrationBuilder.AddPrimaryKey(
                name: "PK_loais",
                table: "loais",
                column: "MaLoai");
        }
    }
}
