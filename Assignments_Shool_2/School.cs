using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class School
    {
        public String Name { get; set; }

        public List<Course> courses { get; set; }
        public List<Assignment> assignments { get; set; }
        public List<Trainer> trainers { get; set; }
        public List<Student> students { get; set; }

        public School()
        {
            this.courses = new List<Course>();
            this.assignments = new List<Assignment>();
            this.trainers = new List<Trainer>();
            this.students = new List<Student>();
        }

        public bool AddCourse()
        {
            try
            {
                Console.Write("Course Name: ");
                string name = Console.ReadLine();
                Course course = new Course(name, this.courses.Count);
                this.courses.Add(course);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCourse()
        {
            try
            {
                Console.WriteLine("Delete course by id:");
                foreach(Course co in this.courses)
                {
                    Console.WriteLine(co.ToString());
                }
                Console.Write("Course Id: ");
                int id = int.Parse(Console.ReadLine());
                foreach (Course co in this.courses)
                {
                    if(co.Id == id)
                    {
                        this.courses.Remove(co);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
