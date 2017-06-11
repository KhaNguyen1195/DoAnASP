﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation
{
    public class CategoryMetaData
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Mã danh mục")]
        [Display(Name = "Mã danh mục")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Tên danh mục")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }


        public string MetaTitle { get; set; }

        public long? ParentID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required(ErrorMessage = "Yêu cầu chọn Trạng thái")]
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
