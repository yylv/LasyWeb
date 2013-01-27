using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PostModel
    {
        [Required]
        [Display(Name = "板块主题")]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "板块ID")]
        public string SubjectID { get; set; }

        [Required]
        [Display(Name = "帖子标题")]
        public string TopicName { get; set; }

        [Required]
        [Display(Name = "帖子内容")]
        public string TopicContent { get; set; }

        [Required]
        [Display(Name = "发表时间")]
        public DateTime AddDateTime { get; set; }

    }
}