using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class Student
    {
        public String Name { get; set; }
        public List<Assignment> assignments { get; set; }

        public List<Course> courses { get; set; }

        public Student(string name)
        {
            this.Name = name;
            this.assignments = new List<Assignment>();
            this.courses = new List<Course>();
        }
    }
}
