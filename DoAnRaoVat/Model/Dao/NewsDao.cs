using Model.EF;
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
    }
}
