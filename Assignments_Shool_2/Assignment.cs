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
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Assignment(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            this.StartDate = DateTime.Today;
            DateTime end = DateTime.Today;
            this.EndDate = end.AddMonths(-1);
        }

        public void Edit()
        {
            Console.WriteLine("Main Imfo(m) ? Related Data(r):");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "m":
                    Console.WriteLine("Edit Name(n) ? StartDate(sd) ? EndDate(ed):");
                    choice = Console.ReadLine();
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
                            break;
                        case "ed":
                            break;
                        default:
                            Console.WriteLine("Enter a valid choice!");
                            break;
                    }
                    break;
                case "r":
                    Console.WriteLine("Edit Assignments:");
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
