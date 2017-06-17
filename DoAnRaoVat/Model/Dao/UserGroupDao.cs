using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserGroupDao
    {
        DoAnASPDBContext db = null;
        public UserGroupDao()
        {
            db = new DoAnASPDBContext();
        }

        public string Insert(UserGroup entity)
        {
            db.UserGroups.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public UserGroup GetByID(string Name)
        {
            return db.UserGroups.SingleOrDefault(x => x.Name == Name);
        }

        public UserGroup ViewDetail(int id)
        {
            return db.UserGroups.Find(id);
        }


        //public IEnumerable<UserGroup> ListAllPaging(string searchString, int page, int pageSize)
        //{
        //    IQueryable<UserGroup> model = db.Categories;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Name.Contains(searchString));
        //    }
        //    return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        //}

        public bool Update(UserGroup entity)
        {
            try
            {
                var group = db.UserGroups.Find(entity.ID);
                group.ID = entity.ID;
                group.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(string id)
        {
            var group = db.UserGroups.SingleOrDefault(x => x.ID == id);
            if (group == null)
            {
                return false;
            }
            db.UserGroups.Remove(group);
            db.SaveChanges();
            return true;
        }

        public List<UserGroup> ListAll()
        {
            return db.UserGroups.Where(x => x.Status == true).ToList();
        }
    }
}
