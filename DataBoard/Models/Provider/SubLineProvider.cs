using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBoard.Models.Provider
{
    public class SubLineProvider : IProvider<SubLine>
    {
        public int Delete(SubLine t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(SubLine t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public List<SubLine> Select()
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                return db.SubLine.Include("History").Include("UserInfo").ToList();
            }
        }

        public int Update(SubLine t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
