using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation
{
    public class ProductMetaData
    {
        [Key]
        public long ID { get; set; }

        [Display(Name="Mã danh mục")]
        [Required(ErrorMessage = "Yêu cầu nhập Mã danh mục")]
        public string Code { get; set; }

        [Display(Name = "Mã danh mục")]
        [Required(ErrorMessage = "Yêu cầu nhập Tên danh mục")]
        public string Name { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Loại danh mục")]
        //[Required(ErrorMessage = "Yêu cầu chọn Danh mục")]
        public long? Category_ID { get; set; }

        public virtual Category Category { get; set; }

    }
}
