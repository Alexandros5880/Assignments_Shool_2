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


        // Import
        #region "Import Course"
        public bool AddCourse()
        {
            Console.WriteLine("Import a Course:");
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
        #endregion
        #region "Import Assignment"
        public bool AddAssignment()
        {
            Console.WriteLine("Import an Assignment:");
            try
            {
                Console.Write("Assignment Name: ");
                string name = Console.ReadLine();
                Assignment assignment = new Assignment(name, this.Assignments.Count);
                this.Assignments.Add(assignment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region "Import Trainer"
        public bool AddTrainer()
        {
            Console.WriteLine("Import Trainer:");
            try
            {
                Console.Write("Trainer Name: ");
                string name = Console.ReadLine();
                Trainer trainer = new Trainer(name, this.Trainers.Count);
                this.Trainers.Add(trainer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region "Import Student"
        public bool AddStudent()
        {
            Console.WriteLine("Import Stuednt:");
            try
            {
                Console.Write("Student Name: ");
                string name = Console.ReadLine();
                Student student = new Student(name, this.Students.Count);
                this.Students.Add(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        // Export
        #region "Get Students How Need To Submit One Ore More Assignments On The Same Week"
        public void PrintStudentsWithAssSameWeek()
        {
            Console.WriteLine("Get Students How Need To Submit One Ore More Assignments On The Same Week:");
            List<Student> students = new List<Student>();
            foreach (Student st in this.Students)
            {
                if(st.Assignments.Count > 0)
                {
                    foreach (Assignment assignment in st.Assignments)
                    {
                        DateTime enddate = assignment.EndDate;
                        DateTime currentdate = DateTime.Today;
                        var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                        var d1 = enddate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(enddate));
                        var d2 = currentdate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(currentdate));
                        if (d1 == d2)
                        {
                            if (!students.Contains(st))
                            {
                                students.Add(st);
                                Console.WriteLine(st.ToString());
                            }
                        }
                    }
                }
            }
            students.Clear();
        }
        #endregion
        #region "Get Students How Belong To More Than One Course"
        public void PrintStudentsWithMoreThanOneCourse()
        {
            Console.WriteLine("Get Students How Belong To More Than One Course:");
            foreach(Student st in this.Students)
            {
                if(st.Courses.Count > 1)
                {
                    Console.WriteLine(st.ToString());
                }
            }
        }
        #endregion
        #region "Print All Assignments Per Student"
        public void PrintAssignmentsPerStudent()
        {
            Console.WriteLine("GetAssignment Per Student:");
            Console.WriteLine("Select student by id:");
            this.PrintStudents();
            int id = int.Parse(Console.ReadLine());
            Student student = (from s in this.Students where s.Id == id select s).FirstOrDefault();
            student.PrintAssignments();
        }
        #endregion
        #region "Print All Assignments Per Course"
        public void PrintAssignmentsPerCourse()
        {
            Console.WriteLine("Get Assignments Per Course:");
            Console.WriteLine("Select course by id:");
            this.PrintCourses();
            int id = int.Parse(Console.ReadLine());
            Course course = (from c in this.Courses where c.Id == id select c).FirstOrDefault();
            course.PrintAssignments();
        }
        #endregion
        #region "Print All Students Per Course"
        public void PrintStudentsPerCourse()
        {
            Console.WriteLine("Get Students Per Course:");
            Console.WriteLine("Select course by id:");
            this.PrintCourses();
            int id = int.Parse(Console.ReadLine());
            Course course = (from c in this.Courses where c.Id == id select c).FirstOrDefault();
            course.PrintStudents();
        }
        #endregion
        #region "Print All Trainers Per Course"
        public void PrintTrainersPerCourse()
        {
            Console.WriteLine("Get Trainers Per Course:");
            Console.WriteLine("Select course by id:");
            this.PrintCourses();
            int id = int.Parse(Console.ReadLine());
            Course course = (from c in this.Courses where c.Id == id select c).FirstOrDefault();
            course.PrintTrainers();
        }
        #endregion
        #region "Get All Students"
        public void PrintStudents()
        {
            Console.WriteLine("Get All Students:");
            foreach (Student st in this.Students)
            {
                Console.WriteLine(st.ToString());
            }
        }
        #endregion
        #region "Get All Trainers"
        public void PrintTrainers()
        {
            Console.WriteLine("Get All Trainers:");
            foreach (Trainer tr in this.Trainers)
            {
                Console.WriteLine(tr.ToString());
            }
        }
        #endregion
        #region "Get All Assignments"
        public void PrintAssignments()
        {
            Console.WriteLine("Get All Assignments:");
            foreach (Assignment ass in this.Assignments)
            {
                Console.WriteLine(ass.ToString());
            }
        }
        #endregion
        #region "Get All Courses"
        public void PrintCourses()
        {
            Console.WriteLine("Get All Courses:");
            foreach (Course cr in this.Courses)
            {
                Console.WriteLine(cr.ToString());
            }
        }
        #endregion

        // Edit
        #region "Edit Course"
        public void EditCourse()
        {
            Console.WriteLine("Edit Course:");
            Console.WriteLine("Select course by id:");
            this.PrintCourses();
            int id = int.Parse(Console.ReadLine());
            Course course = (from c in this.Courses where c.Id == id select c).FirstOrDefault();
            course.Edit();
        }
        #endregion
        #region "Edit Assignment"
        public void EditAssignment()
        {
            Console.WriteLine("Edit Assignment:");
            Console.WriteLine("Select assignment by id:");
            this.PrintAssignments();
            int id = int.Parse(Console.ReadLine());
            Assignment assignment = (from a in this.Assignments where a.Id == id select a).FirstOrDefault();
            assignment.Edit();
        }
        #endregion
        #region "Edit Trainer"
        public void EditTrainer()
        {
            Console.WriteLine("Edit Trainer:");
            Console.WriteLine("Select trainer by id:");
            this.PrintTrainers();
            int id = int.Parse(Console.ReadLine());
            Trainer trainer = (from t in this.Trainers where t.Id == id select t).FirstOrDefault();
            trainer.Edit();
        }
        #endregion
        #region "Edit Student"
        public void EditStudent()
        {
            Console.WriteLine("Edit Student:");
            Console.WriteLine("Select student by id:");
            this.PrintStudents();
            int id = int.Parse(Console.ReadLine());
            Student student = (from s in this.Students where s.Id == id select s).FirstOrDefault();
            student.Edit();
        }
        #endregion
    }
}
