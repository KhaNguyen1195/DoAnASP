using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NewsDao
    {
        DoAnASPDBContext db = null;
        public NewsDao()
        {
            db = new DoAnASPDBContext();
        }

        public long Insert(News entity)
        {
            db.News.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public News GetByID(string Name)
        {
            return db.News.SingleOrDefault(x => x.Name == Name);
        }

        public News ViewDetail(int id)
        {
            return db.News.Find(id);
        }
        
        public IEnumerable<News> LissAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<News> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.City.Name.Contains(searchString) || x.Product.Name.Contains(searchString) );
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(News entity)
        {
            try
            {
                var news = db.News.Find(entity.ID);
                news.Name = entity.Name;
                news.Description = entity.Description;
                news.Price = entity.Price;
                news.ProductID = entity.ProductID;
                news.CityID = entity.CityID;
                //news.ModifiedDate = (DateTime.Now);
                news.Status = entity.Status;
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
            var news = db.News.SingleOrDefault(x => x.ID == id);
            if (news == null)
            {
                return false;
            }
            db.News.Remove(news);
            db.SaveChanges();
            return true;
        }

        public News ViewDetail(long id)
        {
            return db.News.Find(id);
        }

        /*-------------- Thay đổi trạng thái --------------------*/
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
    }
}
