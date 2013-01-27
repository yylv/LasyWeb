using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;
using DB.Model.Objects;

namespace DB.Model.Service
{
    public class VoteService : DBABase
    {
        protected System.Data.Entity.DbSet<Vote> Votes
        {
            get { return this.DBContext.Votes; }
        }

        public DBOprationResult AddVote(Vote vote)
        {
            return new DBOprationResult() { HasError=false  };
        }
    }
}
