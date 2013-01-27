using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model.Objects
{
    public class DBOprationResult
    {
        public bool HasError { get; set; }

        public string ErrorMsg { get; set; }
    }

    public class ArticleOpResult : DBOprationResult
    {
        public string ArticleID { get; set; }
    }
}
