using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 user_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string employee_id { get; set; }
        public Int64? project_id { get; set; }
        public Int64? task_id { get; set; }
        public virtual Tasks Tasks { get; set; }
        public virtual Project Project { get; set; }
    }
}
