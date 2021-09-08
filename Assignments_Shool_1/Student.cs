using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_1
{
    class Student : People
    {
        public int Id { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Course> Courses { get; set; }
        public static List<Student> Students = new List<Student>();

        public Student(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
            this.Assignments = new List<Assignment>();
            this.Courses = new List<Course>();
            this.Id = Student.Students.Count;
            if (!Student.Students.Contains(this))
            {
                Student.Students.Add(this);
            }
        }
        ~Student()
        {
            foreach (Course course in Course.Courses)
            {
                if (course.Students.Contains(this))
                {
                    course.Students.Remove(this);
                }
            }
            foreach (Assignment assignment in Assignment.Assignments)
            {
                if (assignment.Students.Contains(this))
                {
                    assignment.Students.Remove(this);
                }
            }
            Student.Students.Remove(this);
        }
        // Add Student
        public static void Add(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            Student student = new Student(firstname, lastname, age, gender, startdate);
            student.Id = Student.Students.Count;
            if (!Student.Students.Contains(student))
            {
                Student.Students.Add(student);
            }
        }
        // Get Student By Name
        public static Student Get(string firstname, string lastname)
        {
            try
            {
                IEnumerable<Student> students = from student in Student.Students
                                                where student.FirstName == firstname
                                                where student.LastName == lastname
                                                select student;
                return (Student)students.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }
        // Get Student By Id
        public static Student Get(int id)
        {
            try
            {
                IEnumerable<Student> students = from student in Student.Students
                                                where student.Id == id
                                                select student;
                return (Student)students.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }
        // Terminal Add Student
        public static Student TerminalAdd()
        {
            try
            {
                String firstname = "";
                String lastname = "";
                int age = 0;
                String gender = "";
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Student.");
                bool check = true;
                while (check)
                {
                    Console.WriteLine("FirstName: ");
                    firstname = Console.ReadLine();
                    if (firstname.Length > 0)
                    {
                        Console.WriteLine("LastName: ");
                        lastname = Console.ReadLine();
                        if (!(lastname.Length > 0))
                        {
                            Console.WriteLine("Enter a Valid LastName!\n");
                        }
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid FirstName!\n");
                    }
                }
                check = true;
                while (check)
                {
                    Console.WriteLine("Age: ");
                    age = int.Parse(Console.ReadLine());
                    if (age > 0)
                    {
                        Console.WriteLine("Gender: Male(m) Femaile(f)");
                        string gen = Console.ReadLine();
                        if (gen == "m" || gen == "f")
                        {
                            gender = gen;
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid Gender!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Age!\n");
                    }
                }
                // Create The Course Object
                Student.Add(firstname, lastname, age, gender, startdate);
                return Student.Get(firstname, lastname);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
                return null;
            }
        }
        // Terminal Edit a Student
        public static void TerminalEdit()
        {
            bool check = false;
            // Select Student
            Student student;
            int st_id = 0;
            Console.WriteLine("\nSelect Student By Id:");
            foreach (Student st in Student.Students)
            {
                Console.WriteLine(st.ToString());
            }
            Console.Write("ID: ");
            try
            {
                st_id = int.Parse(Console.ReadLine());
                check = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Enter right id!");
                check = false;
            }
            if (check)
            {
                student = (from s in Student.Students where s.Id == st_id select s).FirstOrDefault();
                int age = student.Age;
                string gender = student.Gender;
                string firstname = student.FirstName;
                string lastname = student.LastName;
                string edit_choice = "";
                while (!edit_choice.Equals("q"))
                {
                    Console.Write("Quit(q) Edit: FirstName(f) ? LastName(l) ? Age(a) ? Gender(g): ");
                    edit_choice = Console.ReadLine();
                    switch (edit_choice)
                    {
                        case "q":
                            break;
                        case "f":
                            Console.Write("New FirstName: ");
                            firstname = Console.ReadLine();
                            break;
                        case "l":
                            Console.Write("New LastName: ");
                            lastname = Console.ReadLine();
                            break;
                        case "a":
                            Console.Write("New Age: ");
                            age = int.Parse(Console.ReadLine());
                            break;
                        case "g":
                            Console.Write("Gender: ");
                            gender = Console.ReadLine();
                            break;
                    }
                }
                student.FirstName = firstname;
                student.LastName = lastname;
                student.Age = age;
                student.Gender = gender;
            }
        }
        // Get All Assignments on Terminal
        public static void GetAllAssignmentsTerminal()
        {
            Console.WriteLine("\nSelect Student By Index:");
            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine($"{Students[i].LastName} {Students[i].FirstName}  Index: [{i}]");
            }
            Console.Write("Student Index: ");
            try
            {
                int index = int.Parse(Console.ReadLine());
                Student student = Students[index];
                foreach (Assignment assignment in student.Assignments)
                {
                    Console.WriteLine($"Assignment Title: [{assignment.Title}] StartDate: [{assignment.StartDate}] EndDate: [{assignment.EndDate}]");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter right Index Number!");
            }
        }
        // Get All Students That Belong To More That One Course
        public static void GetAllStudentsThatBelongToMoreThatOneCourse()
        {
            Console.WriteLine("\nGet All Students That Belong To More That One Course");
            foreach (Student student in Student.Students)
            {
                if (student.Courses.Count > 1)
                {
                    Console.WriteLine($"Student: FirstName: [{student.FirstName}] LastName: [{student.LastName}] " +
                                            $"Age: [{student.Age}] Gende: [{student.Gender}] StartDate: [{student.StartDate}]");
                }
            }
        }
        // Exporting All Students Who Need To Submit To Assignments On The Same Week.
        public static void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek()
        {
            List<Student> students = new List<Student>();
            foreach (Student student in Student.Students)
            {
                if (student.Assignments.Count > 0)
                {
                    foreach (Assignment assignment in student.Assignments)
                    {
                        DateTime enddate = assignment.EndDate;
                        DateTime currentdate = DateTime.Today;

                        var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                        var d1 = enddate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(enddate));
                        var d2 = currentdate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(currentdate));

                        if (d1 == d2)
                        {
                            if (!students.Contains(student))
                            {
                                students.Add(student);
                                Console.WriteLine(student.ToString());
                            }
                        }
                    }
                }
            }
            students.Clear();
        }
        // Get All Students On Terminal
        public static new bool GetAllTerminal()
        {
            try
            {
                if (Student.Students.Count > 0)
                {
                    int counter = 0;
                    foreach (Student student in Student.Students)
                    {
                        Console.WriteLine(student.ToString());
                        counter++;
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No Students Found!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return false;
            }
        }

        public override string ToString()
        {
            return $"Student: ID[{this.Id}] Name:[{this.LastName} { this.FirstName}] Age: [{this.Age}] Gende: [{this.Gender}] StartDate: [{this.StartDate}]";
        }
    }
}
