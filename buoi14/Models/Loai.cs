using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace buoi14.Models
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        public string MoTa { get; set; }

        [MaxLength(50)]
        public string Hinh { get; set; }

        // Để lấy dữ liệu hàng hóa khi có MaLoai không cần dùng Linq
        public ICollection<HangHoa> HangHoa { get; set; }
    }
}
