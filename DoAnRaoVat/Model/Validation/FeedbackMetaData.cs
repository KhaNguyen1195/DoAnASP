using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation
{
    public class FeedBackMetaData
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Họ và tên")]
        [Display(Name = "Họ và tên")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [StringLength(250)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [Display(Name = "Email")]
        [StringLength(250)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Địa chỉ")]
        [Display(Name = "Địa chỉ")]
        [StringLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Nội dung phản hồi")]
        [Display(Name = "Nội dung phản hồi")]
        [StringLength(250)]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
