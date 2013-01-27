using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;
using DB.Model.Objects;

namespace DB.Model.Service
{
    public class ArticleService:DBABase
    {
        protected System.Data.Entity.DbSet<Article> Articles
        {
            get { return this.DBContext.Articles; }
        }

        /// <summary>
        /// Description,UserId,Subjet,Content为空的Article
        /// </summary>
        public Article GetNewArticle()
        {
            return new Article()
            {
                ArticleID = Guid.NewGuid().ToString(),
                AddTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };
        }

        public ArticleOpResult AddTextArticle(Article textArticle,TextContent content)
        {
            content.ArticleID = textArticle.ArticleID = Guid.NewGuid().ToString();
            content.ContentID = textArticle.ContentID = Guid.NewGuid().ToString();
            textArticle.ContentType = (int)ContentType.TextContents;
            textArticle.TextContents.Clear();
            textArticle.TextContents.Add(content);
            textArticle.AddTime = DateTime.Now;
            textArticle.UpdateTime = DateTime.Now;
            this.Articles.Add(textArticle);
            //this.DBContext.TextContents.Add(content);
            try
            {
                this.DBContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
            return new ArticleOpResult() { HasError = false , ArticleID=textArticle.ArticleID};
        }

        public ArticleOpResult AddTextArticle(Article textArticle, Vote vote)
        {
            vote.ArticleID = textArticle.ArticleID = Guid.NewGuid().ToString();
            vote.VoteID = textArticle.ContentID = Guid.NewGuid().ToString();
            textArticle.ContentType = (int)ContentType.TextContents;
            textArticle.Votes.Clear();
            textArticle.Votes.Add(vote);
            textArticle.AddTime = DateTime.Now;
            textArticle.UpdateTime = DateTime.Now;
            this.Articles.Add(textArticle);
            return new ArticleOpResult() { HasError = false, ArticleID = textArticle.ArticleID };
        }
    }

    public enum ContentType
    {
        UnKnow=0,
        Votes=1,
        TextContents=2,
    }
}
