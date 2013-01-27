//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB.Model.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
            this.Comments = new HashSet<Comment>();
            this.UsersVotes = new HashSet<UsersVote>();
        }
    
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public System.DateTime LastLoginTime { get; set; }
        public System.DateTime RegistTime { get; set; }
        public string RoleID { get; set; }
        public int IsAdmin { get; set; }
    
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UsersVote> UsersVotes { get; set; }
    }
}