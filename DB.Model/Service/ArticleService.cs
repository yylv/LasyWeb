using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;
using DB.Model.Objects;
using ViewModel.Models;

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

        public ArticleOpResult AddTextArticle(Article article, Vote vote)
        {
            vote.ArticleID = article.ArticleID = Guid.NewGuid().ToString();
            vote.VoteID = article.ContentID = Guid.NewGuid().ToString();
            article.ContentType = (int)ContentType.TextContents;
            article.Votes.Clear();
            article.Votes.Add(vote);
            article.AddTime = DateTime.Now;
            article.UpdateTime = DateTime.Now;
            this.Articles.Add(article);
            return new ArticleOpResult() { HasError = false, ArticleID = article.ArticleID };
        }

        public List<PostModel> ListAllPosts()
        {

            var list = from item in this.Articles
                       select new PostModel()
                       {
                           AddDateTime = item.AddTime,
                           SubjectID = item.SubjectID,
                           SubjectName = item.Subject.Name,
                           TopicContent = item.TextContents.FirstOrDefault().Content,
                           TopicName = item.Tittle
                       };
            return list.ToList();
        }
    }

    public enum ContentType
    {
        UnKnow=0,
        Votes=1,
        TextContents=2,
    }
}
