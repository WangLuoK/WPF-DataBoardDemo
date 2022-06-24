using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBoard.Models;

namespace DataBoard
{
    /// <summary>
    /// 全局数据类
    /// </summary>

    public class AppData : ViewModelBase
    {
        private UserInfo userInfo = new UserInfo() { Name = "admin", Password = "12345"};
       

        /// <summary>
        /// 当前用户
        /// </summary>
        public UserInfo CurrentUser
        {
            get { return userInfo; }
            set { userInfo = value; }
        }

        private List<RoleModel> roleModels;

        public AppData()
        {
            roleModels = new List<RoleModel>
            {
                new RoleModel() { Id = 0, Name = "管理员" },
                new RoleModel() { Id = 1, Name = "普通用户" }
            };

        }

        public List<RoleModel> RoleModels
        {
            get { return roleModels; }
            set { roleModels = value; }
        }


    }
}
