using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School();

            AddTestRecords testRecords = new AddTestRecords(school);
            testRecords.AddRecords();

            while (true)
            {
                Console.WriteLine("Import(i) ? Export(e) ? Edit(ed) ? Quit(q):");
                string choice = Console.ReadLine();
                Console.WriteLine("\n");
                // Importing
                if (choice.Equals("i") || choice.Equals("Import"))
                {
                    Console.WriteLine("Example Enter: t  'to import a Trainer'.");
                    Console.WriteLine("Import: Course(c) ? Assignment(a) ? Trainer(t) ? Student(s)");
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "c":
                            school.AddCourse();
                            break;
                        case "a":
                            school.AddAssignment();
                            break;
                        case "t":
                            school.AddTrainer();
                            break;
                        case "s":
                            school.AddStudent();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice.");
                            break;
                    }
                }
                // Exporting
                else if (choice.Equals("e") || choice.Equals("Export"))
                {
                    Console.WriteLine("Exporting mode!");
                    Console.WriteLine(
                        "Enter for Example: ls\n\t"
                            + "(ls)   -->  [ A list of all the students.                                                                    ]\n\t"
                            + "(lt)   -->  [ A list of all the trainers.                                                                    ]\n\t"
                            + "(la)   -->  [ A list of all the assignments.                                                                 ]\n\t"
                            + "(lc)   -->  [ A list of all the courses.                                                                     ]\n\t"
                            + "(lsc)  -->  [ A List of all the students per course.                                                         ]\n\t"
                            + "(ltc)  -->  [ A List of all the trainers per course.                                                         ]\n\t"
                            + "(lac)  -->  [ A List of all the assignments per course.                                                      ]\n\t"
                            + "(las)  -->  [ A List of all the assignments per student.                                                     ]\n\t"
                            + "(lscm) -->  [ A List of all the students that belong to more than one course.                                ]\n\t"
                            + "(lsd)  -->  [ A List of all the students who need to submit one or more assigment on the same calendar week. ]\n\t"
                    );
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "ls":
                            school.PrintStudents();
                            break;
                        case "lt":
                            school.PrintTrainers();
                            break;
                        case "la":
                            school.PrintAssignments();
                            break;
                        case "lc":
                            school.PrintCourses();
                            break;
                        case "lsc":
                            school.PrintStudentsPerCourse();
                            break;
                        case "ltc":
                            school.PrintTrainersPerCourse();
                            break;
                        case "lac":
                            school.PrintAssignmentsPerCourse();
                            break;
                        case "las":
                            school.PrintAssignmentsPerStudent();
                            break;
                        case "lscm":
                            school.PrintStudentsWithMoreThanOneCourse();
                            break;
                        case "lsd":
                            school.PrintStudentsWithAssSameWeek();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice.");
                            break;
                    }
                }
                // Edit Data
                else if (choice.Equals("ed") || choice.Equals("Edit"))
                {
                    Console.WriteLine("Example Enter: c  'to edit a Course'.");
                    Console.WriteLine("Edit: Course(c) ? Assignment(a) ? Trainer(t) ? Student(s)");
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "c":
                            school.EditCourse();
                            break;
                        case "a":
                            school.EditAssignment();
                            break;
                        case "t":
                            school.EditTrainer();
                            break;
                        case "s":
                            school.EditStudent();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice!");
                            break;
                    }
                }
                // Exit From the program
                else if (choice.Equals("q") || choice.Equals("Quit"))
                {
                    break;
                }
                Console.WriteLine("\n\n");
            }
        }

    }
}
