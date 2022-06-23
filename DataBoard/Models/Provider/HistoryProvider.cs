using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBoard.Models.Provider
{
    public class HistoryProvider : IProvider<History>
    {
        public int Delete(History t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(History t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public List<History> Select()
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                return db.History
                    .Include("Line")
                    .Include("StopType")
                    .Include("SubLine")
                    .Include("UserInfo")
                    .ToList();
            }
        }

        public int Update(History t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
