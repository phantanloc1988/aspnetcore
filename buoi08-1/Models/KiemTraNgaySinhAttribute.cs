using System;
using System.ComponentModel.DataAnnotations;

namespace buoi08_1.Models
{
    internal class KiemTraNgaySinhAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //object value : nhận từ form

            DateTime ngaysinh = (DateTime) value; //ép kiểu
            if (ngaysinh>DateTime.Today)
            {
                return new ValidationResult("ngày sinh trong tương lai");
            }
            return ValidationResult.Success;
        }
    }
}