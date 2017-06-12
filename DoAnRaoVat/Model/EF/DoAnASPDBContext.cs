namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DoAnASPDBContext : DbContext
    {
        public DoAnASPDBContext()
            : base("name=DoAnASP")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_ID);

            modelBuilder.Entity<News>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
