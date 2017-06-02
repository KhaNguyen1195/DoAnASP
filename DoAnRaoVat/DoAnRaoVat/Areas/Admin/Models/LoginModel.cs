using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnRaoVat.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { set; get; }

        public bool RemmemberMe { set; get; }
    }
}