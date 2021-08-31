﻿using System;
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
        public List<Assignment> Assignments { get; set; }
        public List<Course> Courses { get; set; }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            this.Assignments = new List<Assignment>();
            this.Courses = new List<Course>();
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
                            break;
                        case "c":
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
            foreach (Course course in this.Courses)
            {
                Console.WriteLine(course.ToString());
            }
        }
        public void PrintAssignments()
        {
            foreach (Assignment ass in this.Assignments)
            {
                Console.WriteLine(ass.ToString());
            }
        }
        public override string ToString()
        {
            return $"Student: [ID: {this.Id}]  Name: {this.Name}";
        }
    }
}
