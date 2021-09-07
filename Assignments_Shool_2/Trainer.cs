using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class Trainer
    {
        public int Id { get; set; }
        public School school { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }

        public Trainer(string name, int id, School school)
        {
            this.Name = name;
            this.Id = id;
            this.school = school;
            this.StartDate = DateTime.Today;
        }
        public void Edit()
        {
            Console.WriteLine("Edit Name:");
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
        }
        public override string ToString()
        {
            return $"Trainer: [ID: {this.Id}]  Name: {this.Name}";
        }
    }
}
