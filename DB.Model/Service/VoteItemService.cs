using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;
using DB.Model.Objects;

namespace DB.Model.Service
{
    public class VoteItemService : DBABase
    {
        protected System.Data.Entity.DbSet<VoteItem> VoteItems
        {
            get { return this.DBContext.VoteItems; }
        }

        private bool AddSingleVoteItem(VoteItem voteItem, string voteId = null)
        {
            if (voteId != null)
            {
                voteItem.VoteID = voteId;
            }
            if (String.IsNullOrEmpty(voteItem.VoteID) || String.IsNullOrEmpty(voteItem.VoteItemContent))
            {
                return false;
            }
            this.VoteItems.Add(voteItem);
            return true;
        }

        public DBOprationResult AddVoteItems(IList<VoteItem> voteItems, string voteId = null)
        {
            foreach (var item in voteItems)
            {
                if (!this.AddSingleVoteItem(item, voteId))
                {
                    return new DBOprationResult() { HasError = true, ErrorMsg = "VoteID or VoteItemContent is null or empty!" };
                }
            }
            this.DBContext.SaveChanges();
            return new DBOprationResult() { HasError = true };
        }
    }
}
