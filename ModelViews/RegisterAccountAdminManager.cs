using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews
{
    public class RegisterAccountAdminManager
    {
        [Key]
        public int AdminId { get; set; }
        /// <summary>
        /// /////////////
        /// </summary>
        [Display(Name = "Họ Và Tên")]
        [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
        public string Username { get; set; }
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
        public bool Phanquyen { get; set; }
    }
}
