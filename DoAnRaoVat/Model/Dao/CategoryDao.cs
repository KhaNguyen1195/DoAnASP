using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        DoAnASPDBContext db = null;
        public CategoryDao()
        {
            db = new DoAnASPDBContext();
        }

        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Category GetByID(string Name)
        {
            return db.Categories.SingleOrDefault(x => x.Name == Name);
        }

        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }


        public IEnumerable<Category> LissAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(Category entity)
        {
            try
            {
                var category = db.Categories.Find(entity.ID);
                category.Code = entity.Code;
                category.Name = entity.Name;
                category.ModifiedDate =(DateTime.Now);
                category.Status = entity.Status;
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
            var category = db.Categories.SingleOrDefault(x => x.ID == id);
            if (category == null)
            {
                return false;
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return true;
        }

        public List<Category> LissAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }

        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }

        /*-------------- Thay đổi trạng thái --------------------*/
        public bool ChangeStatus(long id)
        {
            var category = db.Categories.Find(id);
            category.Status = !category.Status;
            db.SaveChanges();
            return category.Status;
        }
    }
}
