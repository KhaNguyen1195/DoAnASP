using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class CityDao
    {
        DoAnASPDBContext db = null;
        public CityDao()
        {
            db = new DoAnASPDBContext();
        }

        public long Insert(City entity)
        {
            db.Cities.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public City GetByID(string Name)
        {
            return db.Cities.SingleOrDefault(x => x.Name == Name);
        }

        public City ViewDetail(int id)
        {
            return db.Cities.Find(id);
        }

        public IEnumerable<City> LissAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<City> model = db.Cities;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(City entity)
        {
            try
            {
                var city = db.Cities.Find(entity.ID);
                city.Code = entity.Code;
                city.Name = entity.Name;
                city.Status = entity.Status;
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            var city = db.Cities.SingleOrDefault(x => x.ID == id);
            if(city == null)
            {
                return false;
            }
            db.Cities.Remove(city);
                db.SaveChanges();
            return true;
        }

        public List<City> LissAllCity()
        {
            return db.Cities.Where(x => x.Status == true).ToList();
        }

    }
}
