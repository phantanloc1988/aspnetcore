using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static buoi_20.Common.MyEnum;

namespace buoi_20.DataModels
{
    [Table("HangHoa")]
    public class HangHoa
    {

        [Key]
        public Guid Id { get; set; }

        [MaxLength(10)]
        public string MaHH { get; set; }

        [MaxLength(100)]
        [Required]
        public string TenHH { get; set; }

        public int SoLuong { get; set; }

        public double DonGia { get; set; }

        [MaxLength(200)]
        public string MoTa { get; set; }


        public string Hinh { get; set; }

        [Range(0,100)]
        public  byte GiamGia { get; set; }


        //gắn khóa ngoại
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }

    public class Hinh
    {
        [Key]
        public Guid Id { get; set; }

        public string url { get; set; }

        public LoaiHinh LoaiHinh { get; set; }

        public Guid MaLoai { get; set; }

    }
}
