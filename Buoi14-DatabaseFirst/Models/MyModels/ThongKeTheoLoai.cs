using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_DatabaseFirst.Models.MyModels
{
    public class ThongKeTheoLoai
    {
        [DisplayName("Loại")]
        public string TenLoai { get; set; }

        [DisplayName("Doanh Thu")]
        public double DoanhThu { get; set; }

        [DisplayName("Số Lượng")]
        public int SoLuong { get; set; }

        [DisplayName("Giá Thấp Nhất")]
        public double GiaThapNhat { get; set; }

        [DisplayName("Giá Trung Bình")]
        public double GiaTrungBinh { get; set; }

    }
}
