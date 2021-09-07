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
        public School school { get; set; }
        public String Name { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Course> Courses { get; set; }

        public DateTime StartDate { get; set; }

        public Student(string name, int id, School school)
        {
            this.Name = name;
            this.Id = id;
            this.school = school;
            this.Assignments = new List<Assignment>();
            this.Courses = new List<Course>();
            this.StartDate = DateTime.Today;
        }
        public void Edit()
        {
            Console.WriteLine("Main Imfo(m) ? Related Data(r):");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "m":
                    Console.WriteLine("Edit Name:");
                    Console.Write("Enter a new name: ");
                    string name = Console.ReadLine();
                    if(name.Length > 3)
                    {
                        this.Name = name;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid name!");
                    }
                    break;
                case "r":
                    Console.WriteLine("Edit Assignments(a) ? Courses(c):");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "a":
                            Console.WriteLine("Select Assignment By Id:");
                            this.school.PrintAssignments();
                            int id = int.Parse(Console.ReadLine());
                            Assignment assignment = this.school.GetAssignment(id);
                            Console.WriteLine("Add Assignment(a) ? Remove Assignment(r)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "a": // Add Assignment
                                    if (!this.Assignments.Contains(assignment))
                                    {
                                        this.Assignments.Add(assignment);
                                        Console.WriteLine("Annsginment added succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Assignment Exists!");
                                    }
                                    break;
                                case "r": // Remove Assignment
                                    if (this.Assignments.Contains(assignment))
                                    {
                                        this.Assignments.Remove(assignment);
                                        Console.WriteLine("Annsginment removed succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Assignment Not Exists!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid choice!");
                                    break;
                            }
                            break;
                        case "c":
                            Console.WriteLine("Select Course By Id:");
                            this.school.PrintCourses();
                            id = int.Parse(Console.ReadLine());
                            Course course = this.school.GetCourse(id);
                            Console.WriteLine("Add Course(a) ? Remove Course(r)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "a": // Add Course
                                    if (!this.Courses.Contains(course))
                                    {
                                        this.Courses.Add(course);
                                        Console.WriteLine("Course added succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Course Exists!");
                                    }
                                    break;
                                case "r": // Remove Course
                                    if (this.Courses.Contains(course))
                                    {
                                        this.Courses.Remove(course);
                                        Console.WriteLine("Course removed succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Course Not Exists!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid choice!");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Enter a valid choice!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Enter a valid choice!");
                    break;
            }
        }
        public void PrintCourses()
        {
            if(this.Courses.Count > 0)
            {
                foreach (Course course in this.Courses)
                {
                    Console.WriteLine(course.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nEmpty\n");
            }
        }
        public void PrintAssignments()
        {
            if(this.Assignments.Count > 0)
            {
                foreach (Assignment ass in this.Assignments)
                {
                    Console.WriteLine(ass.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nEmpty\n");
            }
        }
        public override string ToString()
        {
            return $"Student: [ID: {this.Id}]  Name: {this.Name}";
        }
    }
}
