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
    
    public partial class Subject
    {
        public Subject()
        {
            this.Articles = new HashSet<Article>();
        }
    
        public string SubjectID { get; set; }
        public string Name { get; set; }
        public string ParentID { get; set; }
        public System.DateTime AddDateTime { get; set; }
    
        public virtual ICollection<Article> Articles { get; set; }
    }
}
