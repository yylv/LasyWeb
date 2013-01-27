using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB.Model.Service;
using ViewModel.Models;
using Web.Models;

namespace Web.Controllers
{
    public class PostsController : Controller
    {
        #region Service
        private ArticleService articleService;
        protected ArticleService ArticleService
        {
            get
            {
                if (this.articleService == null)
                {
                    this.articleService = new ArticleService();
                }
                return this.articleService;
            }
            set { }
        }

        private CommentService commentService;
        protected CommentService CommentService
        {
            get 
            {
                if (this.commentService == null)
                {
                    this.commentService = new CommentService();
                }
                return this.commentService;
            }
        }

        private TextContentService textContentService;
        protected TextContentService TextContentService
        {
            get
            {
                if (this.textContentService == null)
                {
                    this.textContentService = new TextContentService();
                }
                return this.textContentService;
            }
        }
        #endregion
        
        //
        // GET: /Posts/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Posts/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Posts/Create

        [HttpPost]
        public ActionResult Create(PostModel model)
        {
            try
            {
                var article = this.ArticleService.GetNewArticle();
                article.SubjectID = model.SubjectID;
               // var content=this.TextContentService.
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Posts/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Posts/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, PostModel model)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Posts/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Posts/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, PostModel model)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
