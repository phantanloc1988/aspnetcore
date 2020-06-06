using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buoi08_1.Models
{
    public class NhanVien
    {

        public int ID { get; set; }

        [DisplayName("Mã Nhân Viên")]
        [Required(ErrorMessage ="*")]
        [Remote(action: "KiemTraMaNhanVien", controller: "NhanVien")]
        public int MaNhanVien { get; set; }

        [DisplayName("Tên Nhân Viên")]
        [Required(ErrorMessage = "*")]
        public string TenNhanVien { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Không đúng định dạng")]
        public string Email { get; set; }

        [Url]
        public string Website { get; set; }

        [DisplayName("Ngày Sinh")]
        [DataType(DataType.Date)]
        [KiemTraNgaySinh]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Giới Tính")]
        public string GioiTinh { get; set; }

        [DisplayName("Lương")]
        [Range(0, double.MaxValue)]
        public double Luong { get; set; }

        public string DiaChi { get; set; }

        public string DienThoai { get; set; }

        [CreditCard]
        public string SoTaiKhoan { get; set; }

        [MaxLength (255)]
        [DataType(DataType.MultilineText)]
        public string ThongTinThem { get; set; }

        [Required(ErrorMessage ="*")]
        //[DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Tối thiểu 4 ký tự")]
        [RegularExpression("[0-9]+[a-z]+[A-Z]+@#$%^&*()]+",ErrorMessage ="lỗi rồi")] //dấu + là lặp lại ít nhất 1 lần
        public string MatKhau { get; set; }

        //[DataType(DataType.Password)]
        [Compare("MatKhau")]
        public string NhapLaiMatKhau { get; set; }
    }
}
// ("[0-9a-zA-Z@#$%^&*()]+",ErrorMessage ="Phải có chữ hoa, chữ thường, số, ký tự đặc biệt")
