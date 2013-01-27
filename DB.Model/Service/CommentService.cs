using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;
using DB.Model.Objects;

namespace DB.Model.Service
{
    public class CommentService:DBABase
    {
        protected System.Data.Entity.DbSet<Comment> Comments
        {
            get { return this.DBContext.Comments; }
        }

        public DBOprationResult AddComment(Comment comment,string articleId)
        {
            if (comment.ArticleID == null)
            {
                comment.ArticleID = articleId;
            }
            if(String.IsNullOrEmpty(comment.ArticleID)||String.IsNullOrEmpty(comment.Content))
            {
                return new DBOprationResult() { HasError = true, ErrorMsg = "ArticleID or content is Empty!" };
            }
            comment.CommentID = Guid.NewGuid().ToString();
            comment.CommentTime = DateTime.Now;
            this.Comments.Add(comment);
            this.DBContext.SaveChanges();
            return new DBOprationResult() { HasError=false };
        }
    }
}
