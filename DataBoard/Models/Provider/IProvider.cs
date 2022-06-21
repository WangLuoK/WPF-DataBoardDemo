using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBoard.Models.Provider
{
    public interface IProvider<T> where T : class
    {
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <returns></returns>
        List<T> Select();
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Insert(T t);
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Delete(T t);    
    }
}
