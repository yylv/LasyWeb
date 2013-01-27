using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;
using DB.Model.Objects;
using ViewModel.Models;

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


        public List<CommentModel> ListAllComments()
        {
            var list = from item in this.Comments
                       select new CommentModel()
                       {
                              
                           CommentPostID = item.ArticleID,
                           CommentTime = item.CommentTime,
                           CommentContent = item.Content,
                           UserID=    item.UserID,
                           UserName= item.User.UserName
                       };
            return list.ToList();
        }
        public List<CommentModel> PageListComments(int pageNum,int pageSize)
        {
            var list = this.Comments.Where(a => this.Comments.Any()).Skip(pageSize * pageNum).Take(pageSize).ToList();
            List<CommentModel> CommentModels = new List<CommentModel>();
            foreach (var item in list)
            {
                CommentModel.Add(new CommentModel() 
                {
                           CommentPostID = item.ArticleID,
                           CommentTime = item.CommentTime,
                           CommentContent = item.Content,
                           UserID=    item.UserID,
                           UserName= item.User.UserName
                });
            }
            return CommentModels;
                       
        }
    }
    }
}
