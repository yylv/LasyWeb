using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;
using DB.Model.Objects;

namespace DB.Model.Service
{
    public class UserService : DBABase
    {
        protected System.Data.Entity.DbSet<User> Users 
        {
            get { return this.DBContext.Users; }
        }

        /// <summary>
        /// id,name,等全部为空
        /// </summary>
        /// <returns></returns>
        public User GetNewUser()
        {
            return new User()
            {
                RegistTime = DateTime.Now,
                LastLoginTime = DateTime.Now,
                IsAdmin = 0
            };
        }

        public bool DoesUserNameRepeat(Models.User user)
        {
            var us = (from u in this.Users where u.Pwd == user.Pwd select u).FirstOrDefault();
            if (us == null)
            {
                return false;
            }
            return true;
        }

        public virtual DBOprationResult Regist(Models.User user)
        {
            if (this.DoesUserNameRepeat(user))
            {
                return new DBOprationResult() { HasError = true, ErrorMsg = "用户名已存在！" };
            }
            user.RegistTime = user.LastLoginTime = DateTime.Now;
            user.UserID = Guid.NewGuid().ToString();
            this.Users.Add(user);
            this.DBContext.SaveChanges();
            return new DBOprationResult() { HasError = false };
        }

        public bool Login( Models.User user)
        {
            var us = (from u in this.Users where u.Pwd == user.Pwd && u.UserName == user.UserName select u).FirstOrDefault();
            if (us == null)
            {
                return false;
            }
            user = us;
            return true;
        }
    }
}
