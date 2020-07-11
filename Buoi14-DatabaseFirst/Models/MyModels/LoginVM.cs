using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_DatabaseFirst.Models.MyModels
{
    public class LoginVM
    {
        [DisplayName("Tên Đăng Nhập")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Mật Khẩu")]
        [Required]
        public string Password { get; set; }
    }
}
