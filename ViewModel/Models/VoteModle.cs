using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModel.Models
{
    public class VoteItem
    {
        [Display(Name="选项ID")]
        public string ItemID{get;set;}

        [Required]
        [Display(Name="选项内容")]
        public string ItemContent{get;set;}
    }

    public class VoteModle
    {

        [Required]
        [Display(Name = "发表时间")]
        public DateTime AddDateTime { get; set; }

        [Required]
        [Display(Name="投票主题")]
        public string SingleVoteTitle { get; set; }

        [Required]
        [Display(Name = "投票选项")]
        public List<VoteItem> SingleVoteItem { get; set; }

        [Required]
        [Display(Name = "多选")]
        public bool IsMutipleVote { get; set; }

    }

}