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
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Student> Students { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Course(string name, int id)
        {
            this.Name = name;
            this.Id = id;
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
                            break;
                        case "t":
                            break;
                        case "s":
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
            foreach(Assignment ass in this.Assignments)
            {
                Console.WriteLine(ass.ToString());
            }
        }
        public void PrintStudents()
        {
            foreach (Student st in this.Students)
            {
                Console.WriteLine(st.ToString());
            }
        }
        public void PrintTrainers()
        {
            foreach (Trainer tr in this.Trainers)
            {
                Console.WriteLine(tr.ToString());
            }
        }
        public override string ToString()
        {
            return $"Course: [ID: {this.Id}] {this.Name} StartDate: {this.StartDate} LastDate: {this.EndDate}";
        }
    }
}
