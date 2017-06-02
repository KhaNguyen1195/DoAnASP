namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên tài khoản")]
        public string Username { get; set; }

        [StringLength(250)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(250)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
