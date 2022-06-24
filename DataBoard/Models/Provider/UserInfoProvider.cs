using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBoard.Models.Provider
{
    public class UserInfoProvider : IProvider<UserInfo>
    {
        public int Delete(UserInfo t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public int Insert(UserInfo t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public List<UserInfo> Select()
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                return db.UserInfo
                    .Include("Line")
                    .Include("StopType")
                    .Include("SubLine")
                    .Include("History")
                    .ToList();
            }
        }

        public int Update(UserInfo t)
        {
            using (BoardDBEntities1 db = new BoardDBEntities1())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
