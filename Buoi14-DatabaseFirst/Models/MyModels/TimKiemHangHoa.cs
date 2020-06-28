using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_DatabaseFirst.Models.MyModels
{

    
    public class TimKiemHangHoa
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public double DonGia { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }

        public double GiaBan => DonGia * (1 - GiamGia);
    }
}