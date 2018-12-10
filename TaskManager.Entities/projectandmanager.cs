using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities
{
    public class projectandmanager : Project
    {
        public Int64 user_id { get; set; }
        public Int64 username { get; set; }
    }
}
