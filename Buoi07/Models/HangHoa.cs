using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi07.Models
{
    public class HangHoa
    {

        public int MaHH { get; set; }
        public string TenHH { get; set; }

        public double DonGia { get; set; }
        public double GiamGia { get; set; }

        public string Hinh { get; set; }

        public double GiaBan => DonGia * (100 - GiamGia) / 100.0; // tương đương Get, 0 Set

       

    }
}
