using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModel.Models
{
    public interface IPostContent
    {
    }

    public class PostModelBaseList
    {
        [Required]
        [Display(Name = "板块主题")]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "板块ID")]
        public string SubjectID { get; set; }

        public List<PostModelBase> PostModels { get; set; }
    }

    public class PostModelBase
    {
        public string PostId { get; set; }


        [Display(Name = "板块主题")]
        public List<SubjectModel> SubjectList { get; set; }

        [Required]
        [Display(Name = "板块主题")]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "板块ID")]
        public string SubjectID { get; set; }

        [Required]
        [Display(Name = "帖子标题")]
        public string TopicName { get; set; }

        [Display(Name = "相关评论")]
        public List<CommentModel> Comment { get; set; }

        [Required]
        [Display(Name = "发表时间")]
        public DateTime AddDateTime { get; set; }

        public PostContentType PostContentType { get; set; } 
    }


    public class ContentPostModel:PostModelBase
    {
        [Required]
        [Display(Name = "帖子内容")]
        public string TopicContent { get; set; }
    }

    public class VotesItemModel
    {
        [Display(Name = "选项ID")]
        public string ItemID { get; set; }

        [Required]
        [Display(Name = "选项内容")]
        public string ItemContent { get; set; }
    }

    public class VotePostModle:PostModelBase
    {

        [Required]
        [Display(Name = "投票选项")]
        public List<VotesItemModel> VoteItems { get; set; }

        [Required]
        [Display(Name = "多选")]
        public bool IsMutipleVote { get; set; }

    }

    public enum PostContentType
    {
        UnKnow=0,
        Votes=1,
        TextContents=2,
    }
}