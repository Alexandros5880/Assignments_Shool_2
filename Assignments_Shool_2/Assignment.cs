using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class Assignment
    {
        public String Name { get; set; }
        public Assignment(string name, Course course)
        {
            this.Name = name;
        }
    }
}
