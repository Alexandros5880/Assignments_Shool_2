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

        public List<Course> Courses { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Student> Students { get; set; }

        public School()
        {
            this.Courses = new List<Course>();
            this.Assignments = new List<Assignment>();
            this.Trainers = new List<Trainer>();
            this.Students = new List<Student>();
        }

        public bool AddCourse()
        {
            try
            {
                Console.Write("Course Name: ");
                string name = Console.ReadLine();
                Course course = new Course(name, this.Courses.Count);
                this.Courses.Add(course);
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
                foreach(Course co in this.Courses)
                {
                    Console.WriteLine(co.ToString());
                }
                Console.Write("Course Id: ");
                int id = int.Parse(Console.ReadLine());
                foreach (Course co in this.Courses)
                {
                    if(co.Id == id)
                    {
                        this.Courses.Remove(co);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region "Print All Students Per Course"
        public void PrintStudentsPerCourse()
        {
            Console.WriteLine("Select course by id:");
            this.PrintCourses();
            int id = int.Parse(Console.ReadLine());
            Course course = (from c in this.Courses where c.Id == id select c).FirstOrDefault();
            course.PrintStudents();
        }
        #endregion
        #region "Get All Students"
        public void PrintStudents()
        {
            foreach(Student st in this.Students)
            {
                Console.WriteLine(st.ToString());
            }
        }
        #endregion
        #region "Get All Trainers"
        public void PrintTrainers()
        {
            foreach (Trainer tr in this.Trainers)
            {
                Console.WriteLine(tr.ToString());
            }
        }
        #endregion
        #region "Get All Assignments"
        public void PrintAssignments()
        {
            foreach (Assignment ass in this.Assignments)
            {
                Console.WriteLine(ass.ToString());
            }
        }
        #endregion
        #region "Get All Courses"
        public void PrintCourses()
        {
            foreach (Course cr in this.Courses)
            {
                Console.WriteLine(cr.ToString());
            }
        }
        #endregion
    }
}
