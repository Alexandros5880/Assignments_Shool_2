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

        public override string ToString()
        {
            return $"Assignment: [ID: {this.Id}] {this.Name} StartDate: {this.StartDate} LastDate: {this.EndDate}";
        }
    }
}
