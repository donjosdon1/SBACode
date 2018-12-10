using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities
{
    public class ProjectDetails
    {         
            public Int64 project_id { get; set; }
            public string project { get; set; }
            public DateTime? startdate { get; set; }
            public DateTime? enddate { get; set; }
            public int priority { get; set; }
            public int numberoftasks { get; set; }
            public string Completed { get; set; }
    }
}
