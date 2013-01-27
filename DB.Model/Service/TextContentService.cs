using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;

namespace DB.Model.Service
{
    public class TextContentService:DBABase
    {
        protected System.Data.Entity.DbSet<TextContent> TextContents
        {
            get { return this.DBContext.TextContents; }
        }

    }
}
