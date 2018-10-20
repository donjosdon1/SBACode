using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities
{
    public class ParentTask
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 parent_id { get; set; }
        public string parent_task { get; set; }
        public Tasks Tasks { get; set; }
    }
}
