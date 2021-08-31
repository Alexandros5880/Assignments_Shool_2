using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Assignment> assignments { get; set; }

        public List<Course> courses { get; set; }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            this.assignments = new List<Assignment>();
            this.courses = new List<Course>();
        }

        public override string ToString()
        {
            return $"Student: [ID: {this.Id}]  Name: {this.Name}";
        }
    }
}
