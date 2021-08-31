using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class Course
    {
        public int Id { get; set; }
        public School school { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Student> Students { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Course(string name, int id, School school)
        {
            this.Name = name;
            this.Id = id;
            this.school = school;
            this.Trainers = new List<Trainer>();
            this.Students = new List<Student>();
            this.Assignments = new List<Assignment>();
            this.StartDate = DateTime.Today;
            DateTime end = DateTime.Today;
            this.EndDate = end.AddMonths(-1);
        }
        public void Edit()
        {
            Console.WriteLine("Main Imfo(m) ? Related Data(r):");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "m":
                    Console.WriteLine("Edit Name(n) ? StartDate(sd) ? EndDate(ed):");
                    choice = Console.ReadLine();
                    switch(choice)
                    {
                        case "n":
                            Console.WriteLine("Edit Name:");
                            Console.Write("Enter a new name: ");
                            string name = Console.ReadLine();
                            if (name.Length > 3)
                            {
                                this.Name = name;
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid name!");
                            }
                            break;
                        case "sd":
                            Console.WriteLine("Edit StartDate:");
                            Console.Write("Enter a Date Like (27/07/2021):");
                            DateTime startdate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                            if (startdate > DateTime.Today.AddMonths(-3))
                            {
                                this.StartDate = startdate;
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid date!");
                            }
                            break;
                        case "ed":
                            Console.WriteLine("Edit EndDate:");
                            Console.Write("Enter a Date Like (27/07/2021):");
                            DateTime enddate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                            if (enddate > DateTime.Today.AddDays(3))
                            {
                                this.StartDate = enddate;
                            }
                            else
                            {
                                Console.WriteLine("Enter a valid date!");
                            }
                            break;
                        default:
                            Console.WriteLine("Enter a valid choice!");
                            break;
                    }
                    break;
                case "r":
                    Console.WriteLine("Edit Assignments(a) ? Trainers(t) ? Students(s):");
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
                        case "t":
                            Console.WriteLine("Select Trainer By Id:");
                            this.school.PrintTrainers();
                            id = int.Parse(Console.ReadLine());
                            Trainer trainer = this.school.GetTrainer(id);
                            Console.WriteLine("Add Trainer(a) ? Remove Trainer(r)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "a": // Add Trainer
                                    if (!this.Trainers.Contains(trainer))
                                    {
                                        this.Trainers.Add(trainer);
                                        Console.WriteLine("Trainer added succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Trainer Exists!");
                                    }
                                    break;
                                case "r": // Remove Trainer
                                    if (this.Trainers.Contains(trainer))
                                    {
                                        this.Trainers.Remove(trainer);
                                        Console.WriteLine("Trainer removed succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Trainer Not Exists!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid choice!");
                                    break;
                            }
                            break;
                        case "s":
                            Console.WriteLine("Select Student By Id:");
                            this.school.PrintStudents();
                            id = int.Parse(Console.ReadLine());
                            Student student = this.school.GetStudent(id);
                            Console.WriteLine("Add Student(a) ? Remove Student(r)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "a": // Add Student
                                    if (!this.Students.Contains(student))
                                    {
                                        this.Students.Add(student);
                                        Console.WriteLine("Student added succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Student Exists!");
                                    }
                                    break;
                                case "r": // Remove Student
                                    if (this.Students.Contains(student))
                                    {
                                        this.Students.Remove(student);
                                        Console.WriteLine("Student removed succesfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Student Not Exists!");
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
        public void PrintStudents()
        {
            if(this.Students.Count > 0)
            {
                foreach (Student st in this.Students)
                {
                    Console.WriteLine(st.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nEmpty\n");
            }
        }
        public void PrintTrainers()
        {
            if(this.Trainers.Count > 0)
            {
                foreach (Trainer tr in this.Trainers)
                {
                    Console.WriteLine(tr.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nEmpty\n");
            }
        }
        public override string ToString()
        {
            return $"Course: [ID: {this.Id}] {this.Name} StartDate: {this.StartDate} LastDate: {this.EndDate}";
        }
    }
}
