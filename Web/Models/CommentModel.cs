﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CommentModel
    {
        [Display(Name = "用户ID")]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "评价内容")]
        public string CommentContent { get; set; }

        [Required]
        [Display(Name = "评价帖子")]
        public string CommentTopic { get; set; }

        [Required]
        [Display(Name = "评论时间")]
        public DateTime CommentTime { get; set; }
    }
}