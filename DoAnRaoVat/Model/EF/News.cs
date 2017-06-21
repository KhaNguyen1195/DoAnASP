namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class News
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [NotMapped]
        public string FirstImage
        {
            get
            {
                if (!string.IsNullOrEmpty(Image))
                {
                    string[] ars = Image.Split(';');
                    foreach (var item in ars)
                    {
                        if (!string.IsNullOrEmpty(item.Trim()))
                        {
                            return item;
                        }
                    }
                }
                return null;
            }
        }

        public string Image { get; set; }

        public decimal? Price { get; set; }

        public long? ProductID { get; set; }

        public long? CityID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        public int? ViewCount { get; set; }

        public virtual City City { get; set; }

        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
    }
}
