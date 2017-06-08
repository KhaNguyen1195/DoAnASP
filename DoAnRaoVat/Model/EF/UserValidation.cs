using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    class UserValidation
    {
        [Key]
        public long ID { get; set; }


        [StringLength(250)]
        [Display(Name = "Tên đăng nhập"), Required(ErrorMessage = "Chưa nhập tên đăng nhập")]
        public string Username { get; set; }

        [StringLength(250)]
        [Display(Name = "Mật khẩu"), Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string Password { get; set; }

        [StringLength(250)]
        [Display(Name = "Họ và tên"), Required(ErrorMessage = "Chưa nhập họ tên")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ"), Required(ErrorMessage = "Chưa nhập địa chỉ")]
        public string Address { get; set; }

        [StringLength(250)]
        [Display(Name = "Email"), Required(ErrorMessage = "Chưa nhập email")]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Số điện thoại"), Required(ErrorMessage = "Chưa nhập số điện thoại")]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Trạng thái"), Required(ErrorMessage = "Chưa chọn trạng thái")]
        public bool Status { get; set; }
    }
}
