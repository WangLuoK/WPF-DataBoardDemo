using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBoard.Models
{
    public partial class UserInfo
    {
        public RoleModel RoleModel { get; set; } = new RoleModel();
    }
}
