using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities
{
    public class Tasks
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 task_id { get; set; }
        
        public Int64? parent_id { get; set; }
        public Int64? project_id { get; set; }

        public string task { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public int priority { get; set; }
        public int taskended { get; set; }
        public virtual ParentTask ParentTask { get; set; }
        public virtual Project Project { get; set; }
    }
}
