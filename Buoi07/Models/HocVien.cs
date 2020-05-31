using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi07.Models
{
    public class HocVien
    {
        [DisplayName("Mã Học Viên")]
        public int MaSo { get; set; }

        [DisplayName("Họ Tên Học Viên")]
        public string HoTen { get; set; }

        [DisplayName("Số Điện Thoại")]
        public string SoDT { get; set; }

        [DisplayName("Điểm Trung Bình")]
        public double DiemTb { get; set; }

        [DisplayName("Giới Tính")]
        public bool GioiTinh { get; set; }
    }
}
