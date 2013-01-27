using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Service
{
    public class AdminService : UserService
    {
        public override Objects.DBOprationResult Regist(Models.User user)
        {
            user.IsAdmin = 1;
            return base.Regist(user);
        }
    }
}
