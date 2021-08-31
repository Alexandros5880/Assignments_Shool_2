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
        public String Name { get; set; }
        public Trainer(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"Trainer: [ID: {this.Id}]  Name: {this.Name}";
        }
    }
}
