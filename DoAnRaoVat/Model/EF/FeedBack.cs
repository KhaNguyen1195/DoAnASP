namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Validation;

    [Table("FeedBack")]
    [MetadataType(typeof(FeedBackMetaData))]
    public partial class FeedBack
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool Status { get; set; }
    }
}
