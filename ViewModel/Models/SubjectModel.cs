using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Models
{
    public class SubjectModel
    {

        [Required]
        [Display(Name = "板块主题")]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "板块ID")]
        public string SubjectID { get; set; }

    }
}
