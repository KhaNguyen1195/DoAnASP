using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation
{
    public class CityMetaData
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Mã thành phố")]
        [Display(Name = "Mã thành phố")]
        [StringLength(50)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Tên thành phố")]
        [Display(Name = "Tên thành phố")]
        [StringLength(50)]
        public string Name { get; set; }

        
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
