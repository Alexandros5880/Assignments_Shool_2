using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_1
{
    class Assignment
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses = new List<Course>();
        public static List<Assignment> Assignments = new List<Assignment>();

        public Assignment()
        {
            this.Students = new List<Student>();
            this.Id = Assignment.Assignments.Count;
            if (!Assignment.Assignments.Contains(this))
            {
                Assignment.Assignments.Add(this);
            }
        }
        ~Assignment()
        {
            Assignment.Assignments.Remove(this);
        }
        // Add Assignment
        public static void Add(string title, DateTime startdate, DateTime enddate)
        {
            Assignment assignment = new Assignment();
            assignment.Title = title;
            assignment.StartDate = startdate;
            assignment.EndDate = enddate;
            assignment.Id = Assignment.Assignments.Count;
            if (!Assignment.Assignments.Contains(assignment))
            {
                Assignment.Assignments.Add(assignment);
            }
        }
        // Get Assignment By Title
        public static Assignment Get(string title)
        {
            try
            {
                IEnumerable<Assignment> assignments = from assignment in Assignment.Assignments
                                                      where assignment.Title == title
                                                      select assignment;
                return (Assignment)assignments.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }
        // Get Assignment By Id
        public static Assignment Get(int id)
        {
            try
            {
                IEnumerable<Assignment> assignments = from assignment in Assignment.Assignments
                                                      where assignment.Id == id
                                                      select assignment;
                return (Assignment)assignments.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }
        // Terminal Add Assignment
        public static Assignment TerminalAdd()
        {
            try
            {
                String title = "";
                DateTime enddate = DateTime.Today;
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Assignment.");
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Give a Title: ");
                    title = Console.ReadLine();
                    if (title.Length > 0)
                    {
                        Console.WriteLine("Set the End Date:");
                        Console.WriteLine($"example: {DateTime.Today.ToString("dd/MM/yyyy")}");
                        String date = Console.ReadLine();
                        String[] dates = date.Split('/');
                        enddate = new DateTime(int.Parse(dates[2]), int.Parse(dates[0]), int.Parse(dates[1]), 0, 0, 0);
                        if (enddate > DateTime.Today)
                        {
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid End Date!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Title!\n");
                    }
                }
                // Create The Course Object
                Assignment.Add(title, enddate, startdate);
                return Assignment.Get(title);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
                return null;
            }
        }
        // Terminal Edit an Assignment
        public static void TerminalEdit()
        {
            bool check = false;
            // Select Assignment
            Assignment myassignment;
            int as_id = 0;
            Console.WriteLine("\nSelect Assignment By Id:");
            foreach (Assignment ass in Assignment.Assignments)
            {
                Console.WriteLine(ass.ToString());
            }
            Console.Write("ID: ");
            try
            {
                as_id = int.Parse(Console.ReadLine());
                check = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Enter right id!");
                check = false;
            }
            if (check)
            {
                myassignment = (from a in Assignment.Assignments where a.Id == as_id select a).FirstOrDefault();
                // Select What to Edit On Course
                Console.WriteLine("Quit(q) Edit: Students(s) ? Course(c) ? Edit Main Imfo(m)");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "s": // Edit Students
                        Console.WriteLine("Quit(q) Add Student(a) ? Remove Student(r)");
                        String choice_s_ar = Console.ReadLine();
                        Student student;
                        switch (choice_s_ar)
                        {
                            case "a": // Add Studentr
                                Console.WriteLine("Add Existing Student: (ex) ? Add New Student: (new)");
                                String choice_t = Console.ReadLine();
                                switch (choice_t)
                                {
                                    case "ex":
                                        if (Student.GetAllTerminal())
                                        {
                                            Console.WriteLine("Select Student By Id:");
                                            int id = int.Parse(Console.ReadLine());
                                            student = Student.Students[id];
                                        }
                                        else
                                        {
                                            student = null;
                                        }
                                        break;
                                    case "new":
                                        student = Student.TerminalAdd();
                                        break;
                                    default:
                                        Console.WriteLine("Enter a Valid Choice!");
                                        student = null;
                                        break;
                                }
                                if (student != null)
                                {
                                    myassignment.Students.Add(student);
                                    student.Assignments.Add(myassignment);
                                }
                                else
                                {
                                    Console.WriteLine("Please Try Again!");
                                }
                                break;
                            case "r": // Remove Student
                                if (myassignment.Students.Count > 0)
                                {
                                    int count = 0;
                                    foreach (Student stdn in myassignment.Students)
                                    {
                                        Console.WriteLine($"Student: Id: [{count}] FirstName: [{stdn.FirstName}]  LastName: [{stdn.LastName}]  " +
                                                                                $"Age: [{stdn.Age}]  Gende: [{stdn.Gender}]  StartDate: [{stdn.StartDate}]");
                                        count++;
                                    }
                                    Console.WriteLine("Select Student By Id:");
                                    int id = int.Parse(Console.ReadLine());
                                    student = myassignment.Students[id];
                                    Console.WriteLine($"Course Students: {myassignment.Students.Count}");
                                    Console.WriteLine($"Removing Student: {student.FirstName} {student.LastName}");
                                    student.Assignments.Remove(myassignment);
                                    myassignment.Students.Remove(student);
                                    Console.WriteLine($"Assignment Studetns: {myassignment.Students.Count}");
                                }
                                else
                                {
                                    Console.WriteLine("No Students Exists in this Assignment!");
                                }
                                break;
                            case "q":
                                break;
                        }
                        break;
                    case "c": // Edit Course
                        Console.WriteLine("Quit(q) Add Course(a) ? Remove Course(r)");
                        String choice_a_ar = Console.ReadLine();
                        Course course;
                        switch (choice_a_ar)
                        {
                            case "a": // Add Course
                                Console.WriteLine("Add Existing Course: (ex) ? Add New Course: (new)");
                                String choice_t = Console.ReadLine();
                                switch (choice_t)
                                {
                                    case "ex":
                                        if (Course.GetAllTerminal())
                                        {
                                            Console.WriteLine("Select Course By Id:");
                                            int id = int.Parse(Console.ReadLine());
                                            course = Course.Courses[id];
                                        }
                                        else
                                        {
                                            course = null;
                                        }
                                        break;
                                    case "new":
                                        course = Course.TerminalAdd();
                                        break;
                                    default:
                                        Console.WriteLine("Enter a Valid Choice!");
                                        course = null;
                                        break;
                                }
                                if (course != null)
                                {
                                    course.Assignments.Add(myassignment);
                                    myassignment.Courses.Add(course);
                                }
                                else
                                {
                                    Console.WriteLine("Please Try Again!");
                                }
                                break;
                            case "r": // Remove Course
                                if (myassignment.Courses.Count > 0)
                                {
                                    int count = 0;
                                    foreach (Course cor in myassignment.Courses)
                                    {
                                        Console.WriteLine($"Course: Id: [{count}] Title: [{cor.Title}]  StartDate: [{cor.StartDate}]  EndDate: [{cor.EndDate}]");
                                        count++;
                                    }
                                    Console.WriteLine("Select Course By Id:");
                                    int id = int.Parse(Console.ReadLine());
                                    course = myassignment.Courses[id];
                                    Console.WriteLine($"Assignment Courses: {myassignment.Courses.Count}");
                                    Console.WriteLine($"Removing Course: {course.Title}");
                                    myassignment.Courses.Remove(course);
                                    course.Assignments.Remove(myassignment);
                                    Console.WriteLine($"Assignment Courses: {myassignment.Courses.Count}");
                                }
                                else
                                {
                                    Console.WriteLine("No Courses Exists in this Assignment!");
                                }
                                break;
                            case "q":
                                break;
                        }
                        break;
                    case "m": // Edit Main Imfo
                        Console.WriteLine("Quit(q) Do you wont to change Title(t) or EndDate(ed):");
                        string choice_m = Console.ReadLine();
                        switch (choice_m)
                        {
                            case "t":
                                Console.Write("Enter New Title: ");
                                string c_title = Console.ReadLine();
                                if (c_title.Length > 0)
                                {
                                    myassignment.Title = c_title;
                                }
                                else
                                {
                                    Console.WriteLine("Enter a Valid Choice!");
                                }
                                break;
                            case "ed":
                                Console.Write("Enter a Date Like (27/07/2021):");
                                String date = Console.ReadLine();
                                String[] dates = date.Split('/');
                                DateTime enddate = new DateTime(int.Parse(dates[2]), int.Parse(dates[0]), int.Parse(dates[1]), 0, 0, 0);
                                if (enddate > DateTime.Today)
                                {
                                    myassignment.EndDate = enddate;
                                }
                                else
                                {
                                    Console.WriteLine("Enter a Valid Choice!");
                                }
                                break;
                            case "q":
                                break;
                        }
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Choice!");
                        break;

                }
            }
        }
        // Get All Assignments On Terminal
        public static bool GetAllTerminal()
        {
            try
            {
                if (Assignment.Assignments.Count > 0)
                {
                    foreach (Assignment assignment in Assignment.Assignments)
                    {
                        Console.WriteLine(assignment.ToString());
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No Assignments Found!");
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
            return $"Assignment: ID[{this.Id}] Title: [{this.Title}] StartDate: [{this.StartDate}] EndDate: [{this.EndDate}]";
        }
    }
}
