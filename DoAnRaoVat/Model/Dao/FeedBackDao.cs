using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedBackDao
    {
        DoAnASPDBContext db = null;
        public FeedBackDao()
        {
            db = new DoAnASPDBContext();
        }

        public long Insert(FeedBack entity)
        {
            db.FeedBacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public FeedBack GetByID(string Name)
        {
            return db.FeedBacks.SingleOrDefault(x => x.Name == Name);
        }

        public FeedBack ViewDetail(int id)
        {
            return db.FeedBacks.Find(id);
        }

        public IEnumerable<FeedBack> LissAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<FeedBack> model = db.FeedBacks;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(FeedBack entity)
        {
            try
            {
                var feedback = db.FeedBacks.Find(entity.ID);
                feedback.Name = entity.Name;
                feedback.Phone = entity.Phone;
                feedback.Email = entity.Email;
                feedback.Address = entity.Address;
                feedback.Content = entity.Content;
                feedback.Status = entity.Status;
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
            var feedback = db.FeedBacks.SingleOrDefault(x => x.ID == id);
            if (feedback == null)
            {
                return false;
            }
            db.FeedBacks.Remove(feedback);
            db.SaveChanges();
            return true;
        }
    }
}
