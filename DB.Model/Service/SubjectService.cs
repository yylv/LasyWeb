using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Models;

namespace DB.Model.Service
{
    public class SubjectService:DBABase
    {
        protected System.Data.Entity.DbSet<Subject> Subjects
        {
            get { return this.DBContext.Subjects; }
        }

    }
}
