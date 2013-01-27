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
            textArticle.ContentType = (int)PostContentType.TextContents;
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
            article.ContentType = (int)PostContentType.TextContents;
            article.Votes.Clear();
            article.Votes.Add(vote);
            article.AddTime = DateTime.Now;
            article.UpdateTime = DateTime.Now;
            this.Articles.Add(article);
            return new ArticleOpResult() { HasError = false, ArticleID = article.ArticleID };
        }

        public List<PostModelBase> ListAllPosts()
        {

            var list = from item in this.Articles
                       select (PostContentType)item.ContentType == PostContentType.TextContents ?
                       new ContentPostModel()
                       {
                           AddDateTime = item.AddTime,
                           SubjectID = item.SubjectID,
                           SubjectName = item.Subject.Name,
                           TopicName = item.Tittle,
                           PostContentType=PostContentType.TextContents,
                       } as PostModelBase :
                       new VotePostModle()
                       {
                           AddDateTime = item.AddTime,
                           SubjectID = item.SubjectID,
                           SubjectName = item.Subject.Name,
                           TopicName = item.Tittle,
                           PostContentType = PostContentType.Votes,
                       } as PostModelBase;
            return list.ToList();
        }

        private PostModelBase GetPostModelFromArticle(Article article,TextContent textContent,Vote vote,list<VoteItem> voteItems)
        {
            switch ((PostContentType)article.ContentType)
            {
                case PostContentType.TextContents:
                    return new ContentPostModel()
                    {
                        AddDateTime = article.AddTime,
                        SubjectID = article.SubjectID,
                        SubjectName = article.Subject.Name,
                        TopicName = article.Tittle,
                        PostContentType = PostContentType.TextContents,
                        TopicContent = textContent.Content
                    };
                    break;
                case PostContentType.Votes:
                    var item= new VotePostModle()
                    {
                        AddDateTime = article.AddTime,
                        SubjectID = article.SubjectID,
                        SubjectName = article.Subject.Name,
                        TopicName = article.Tittle,
                        PostContentType = PostContentType.TextContents,
                        IsMutipleVote = vote.IsMultiple > 1,
                    };
                    var list = from it in voteItems select new VotesItem() { };
                    item.VoteItems = list;
                    return item;
                    break;
                default:
                    return null;
                    break;
            }
            
        }

        public ArticleOpResult AddNewArticle(PostModelBase model)
        {
            throw new NotImplementedException();
        }

        public PostModelBase GetPostModelById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeletePostById(string id)
        {
            throw new NotImplementedException();
        }
    }

    
}
