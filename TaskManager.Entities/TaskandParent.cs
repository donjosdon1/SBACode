using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities
{
    public class TaskandParent
    {
        public Int64 task_id { get; set; }

        public Int64? parent_id { get; set; }

        public string task { get; set; }
        public string parent_task { get; set; }
        public Int64? project_id { get; set; }
        public Int64? user_id { get; set; }
        public string project { get; set; }
        public string username { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public int priority { get; set; }
        public int taskended { get; set; }
        public int isparent { get; set; }
    }
}
