using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class Assignment
    {
        public int Id { get; set; }
        public School school { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Assignment(string name, int id, School school)
        {
            this.Name = name;
            this.Id = id;
            this.school = school;
            this.StartDate = DateTime.Today;
            DateTime end = DateTime.Today;
            this.EndDate = end.AddMonths(-1);
        }
        public void Edit()
        {
            Console.WriteLine("Edit Assignment:");
            Console.WriteLine("Edit Name(n) ? StartDate(sd) ? EndDate(ed):");
            string choice = Console.ReadLine();
            switch (choice)
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
        }
        public override string ToString()
        {
            return $"Assignment: [ID: {this.Id}] {this.Name} StartDate: {this.StartDate} LastDate: {this.EndDate}";
        }
    }
}
