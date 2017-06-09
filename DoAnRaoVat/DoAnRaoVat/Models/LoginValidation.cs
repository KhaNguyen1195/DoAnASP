using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnRaoVat.Models
{
    public class LoginValidation
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { set; get; }

        public bool RemmemberMe { set; get; }
    }
}