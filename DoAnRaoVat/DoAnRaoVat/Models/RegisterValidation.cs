using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnRaoVat.Models
{
    public class RegisterValidation
    {
        [Key]
        public long ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập Tên đăng nhập")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên.")]
        [Required(ErrorMessage = "Yêu cầu nhập Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Yêu cầu nhập Họ tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập Số điện thoại")]
        public string Phone { get; set; }
    }
}