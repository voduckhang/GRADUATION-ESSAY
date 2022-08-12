using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews
{
    public class RegisterVM
    {
        [Key]
        public int CustomerId { get; set; }
        /// <summary>
        /// /////////////
        /// </summary>
        [Display(Name = "Họ Và Tên")]
        [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
        public string FullName { get; set; }
        /// <summary>
        /// ///////
        /// </summary>

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "ValidateEmail", controller: "Account")]
        public string Email { get; set; }
        /// <summary>
        /// /////
        /// </summary>
        
        [MinLength(10,ErrorMessage ="Số điện thoại của bạn không đủ 10 chữ số")]
        [MaxLength(10, ErrorMessage = "Số điện thoại của bạn không đủ 10 chữ số")]
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại")]
        [Display(Name = "Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "ValidatePhone", controller: "Account")]
        public string Phone { get; set; }
        /// <summary>
        /// ///////
        /// </summary>
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        public string Password { get; set; }
        /// <summary>
        /// ////////
        /// </summary>
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Vui lòng nhập mật khẩu giống nhau")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập ngày")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}")]
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
    }
}
