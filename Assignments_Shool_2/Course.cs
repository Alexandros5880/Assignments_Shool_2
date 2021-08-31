﻿using System;
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
