﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_1
{
    class Trainer : People
    {
        public int Id { get; set; }
        public List<Course> Courses { get; set; }
        public static List<Trainer> Trainers = new List<Trainer>();

        public Trainer(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
            this.Courses = new List<Course>();
            this.Id = Trainer.Trainers.Count;
            if(!Trainer.Trainers.Contains(this))
            {
                Trainer.Trainers.Add(this);
            }
        }
        ~Trainer()
        {
            foreach (Course course in Course.Courses)
            {
                if (course.Trainers.Contains(this))
                {
                    course.Trainers.Remove(this);
                }
            }
            Trainer.Trainers.Remove(this);
        }
        // Add Trainer
        public static void Add(string firstname, string lastname, int age, string gender, DateTime startdate)
        {
            Trainer trainer = new Trainer(firstname, lastname, age, gender, startdate);
            trainer.Id = Trainer.Trainers.Count;
            if (!Trainer.Trainers.Contains(trainer))
            {
                Trainer.Trainers.Add(trainer);
            }
        }
        // Get Trainer By Name
        public static Trainer Get(string firstname, string lastname)
        {
            try
            {
                IEnumerable<Trainer> traners = from trainer in Trainer.Trainers
                                               where trainer.FirstName == firstname
                                               where trainer.LastName == lastname
                                               select trainer;

                return (Trainer)traners.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }
        // Get Trainer By Id
        public static Trainer Get(int id)
        {
            try
            {
                IEnumerable<Trainer> traners = from trainer in Trainer.Trainers
                                               where trainer.Id == id
                                               select trainer;

                return (Trainer)traners.ToList().First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n {ex.Message} \n\n");
                return null;
            }
        }
        // Terminal Add Trainer
        public static Trainer TerminalAdd()
        {
            try
            {
                String firstname = "";
                String lastname = "";
                int age = 0;
                String gender = "";
                DateTime startdate = DateTime.Today;

                Console.WriteLine("Creating New Trainer.");
                bool check = true;
                while (check)
                {
                    Console.WriteLine("FirstName: ");
                    firstname = Console.ReadLine();
                    if (firstname.Length > 0)
                    {
                        Console.WriteLine("LastName: ");
                        lastname = Console.ReadLine();
                        if (!(lastname.Length > 0))
                        {
                            Console.WriteLine("Enter a Valid LastName!\n");
                        }
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid FirstName!\n");
                    }
                }
                check = true;
                while (check)
                {
                    Console.WriteLine("Age: ");
                    age = int.Parse(Console.ReadLine());
                    if (age > 0)
                    {
                        Console.WriteLine("Gender: Male(m) Femaile(f)");
                        string gen = Console.ReadLine();
                        if (gen == "m" || gen == "f")
                        {
                            gender = gen;
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid Gender!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Age!\n");
                    }
                }
                // Create The Course Object
                Trainer.Add(firstname, lastname, age, gender, startdate);
                return Trainer.Get(firstname, lastname);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine($"\n\nException: {ex.Message}\n\n");
                return null;
            }
        }
        // Terminal Edit a Trainer
        public static void TerminalEdit()
        {
            bool check = false;
            // Select Trainer
            Trainer trainer;
            int tr_id = 0;
            Console.WriteLine("\nSelect Trainer By Id:");
            foreach (Trainer tr in Trainer.Trainers)
            {
                Console.WriteLine(tr.ToString());
            }
            Console.Write("ID: ");
            try
            {
                tr_id = int.Parse(Console.ReadLine());
                check = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Enter right id!");
                check = false;
            }
            if (check)
            {
                trainer = (from t in Trainer.Trainers where t.Id == tr_id select t).FirstOrDefault();
                int age = trainer.Age;
                string gender = trainer.Gender;
                string firstname = trainer.FirstName;
                string lastname = trainer.LastName;
                string edit_choice = "";
                while (!edit_choice.Equals("q"))
                {
                    Console.Write("Quit(q) Edit: FirstName(f) ? LastName(l) ? Age(a) ? Gender(g): ");
                    edit_choice = Console.ReadLine();
                    switch (edit_choice)
                    {
                        case "q":
                            break;
                        case "f":
                            Console.Write("New FirstName: ");
                            firstname = Console.ReadLine();
                            break;
                        case "l":
                            Console.Write("New LastName: ");
                            lastname = Console.ReadLine();
                            break;
                        case "a":
                            Console.Write("New Age: ");
                            age = int.Parse(Console.ReadLine());
                            break;
                        case "g":
                            Console.Write("New FirstName: Gender: ");
                            gender = Console.ReadLine();
                            break;
                    }
                }
                trainer.FirstName = firstname;
                trainer.LastName = lastname;
                trainer.Age = age;
                trainer.Gender = gender;
            }
        }
        // Get All Traines On Terminal
        public static new bool GetAllTerminal()
        {
            try
            {
                if (Trainer.Trainers.Count > 0)
                {
                    int counter = 0;
                    foreach (Trainer trainer in Trainer.Trainers)
                    {
                        Console.WriteLine(trainer.ToString());
                        counter++;
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No Trainer Found!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return false;
            }
        }

        public override string ToString()
        {
            return $"Trainer: ID[{this.Id}] Name:[{this.LastName} { this.FirstName}] Age: [{this.Age}] Gende: [{this.Gender}] StartDate: [{this.StartDate}]";
        }
    }
}
