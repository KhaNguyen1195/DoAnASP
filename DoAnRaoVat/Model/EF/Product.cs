namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            News = new HashSet<News>();
        }

        public long ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool Status { get; set; }

        public long? Category_ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
    }
}
