using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        DoAnASPDBContext db = null;
        public ProductCategoryDao()
        {
            db = new DoAnASPDBContext();
        }

        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public ProductCategory GetByID(string Name)
        {
            return db.ProductCategories.SingleOrDefault(x => x.Name == Name);
        }

        public ProductCategory ViewDetail(int id)
        {
            return db.ProductCategories.Find(id);
        }


        public IEnumerable<ProductCategory> LissAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(ProductCategory entity)
        {
            try
            {
                var productcategory = db.ProductCategories.Find(entity.ID);
                productcategory.Name = entity.Name;
                productcategory.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            var productcategory = db.ProductCategories.SingleOrDefault(x => x.ID == id);
            if (productcategory == null)
            {
                return false;
            }
            db.ProductCategories.Remove(productcategory);
            db.SaveChanges();
            return true;
        }
    }
}
