//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB.Model.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VoteItem
    {
        public VoteItem()
        {
            this.UsersVotes = new HashSet<UsersVote>();
        }
    
        public string VoteItemID { get; set; }
        public string VoteItemContent { get; set; }
        public int Count { get; set; }
        public string VoteID { get; set; }
    
        public virtual ICollection<UsersVote> UsersVotes { get; set; }
        public virtual Vote Vote { get; set; }
    }
}
