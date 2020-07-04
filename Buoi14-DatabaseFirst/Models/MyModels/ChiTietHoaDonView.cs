using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_DatabaseFirst.Models.MyModels
{
    public class ChiTietHoaDonView
    {
        public int MaHD { get; set; }
        public string TenLoai { get; set; }

        public string TenHH { get; set; }

        public double DonGia { get; set; }

        public int SoLuong { get; set; }

        public double GiamGia { get; set; }

        public double ThanhTien => DonGia * SoLuong * (1 - GiamGia);
    }
}
