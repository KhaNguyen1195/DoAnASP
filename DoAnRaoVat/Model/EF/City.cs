namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên khu vực")]
        public string Name { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
