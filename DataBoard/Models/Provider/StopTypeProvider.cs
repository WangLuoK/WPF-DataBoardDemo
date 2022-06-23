using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBoard.Models.Provider
{
    public class StopTypeProvider : IProvider<StopType>
    {
        public int Delete(StopType t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(StopType t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public List<StopType> Select()
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                return db.StopType.Include("History").Include("UserInfo").ToList();
            }
        }

        public int Update(StopType t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
