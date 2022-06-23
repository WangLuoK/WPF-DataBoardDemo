using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBoard.Models.Provider
{
    public class LineProvider : IProvider<Line>
    {
        public int Delete(Line t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(Line t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public List<Line> Select()
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                return db.Line.Include("UserInfo").ToList();
            }
        }

        public int Update(Line t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
