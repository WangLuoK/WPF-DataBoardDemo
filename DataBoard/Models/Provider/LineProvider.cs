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
            throw new NotImplementedException();
        }

        public int Insert(Line t)
        {
            throw new NotImplementedException();
        }

        public List<Line> Select()
        {
            using (BoardDBEntities db = new BoardDBEntities())
            {
                return db.Line.Include("UserInfo").ToList();
            }
        }

        public int Update(Line t)
        {
            throw new NotImplementedException();
        }
    }
}
