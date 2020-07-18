using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace buoi_20.DataModels
{
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }

        [MaxLength(100)]
        [Required]
        public string TenLoai { get; set; }

        public int? MaLoaiCha { get; set; }
        [ForeignKey("MaLoaiCha")]

        public Loai LoaiCha {get;set;}


    }
}
