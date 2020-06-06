using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buoi08_1.Models
{
    public class EmployeeInfo
    {
        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage ="Nhập tên")]
        public string FullName { get; set; }

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage ="nhập tuổi")]
        public int Age { get; set; }

        [Display(Name = "Mô Tả")]
        [MaxLength(255, ErrorMessage = "tối đa 255 ký tự")]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }
    }
}
