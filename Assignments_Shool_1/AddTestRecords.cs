using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_1
{
    class AddTestRecords
    {

        public AddTestRecords()
        {
        }

        public void AddRecords()
        {
            for(int i = 0; i < 30; i++)
            {
                Course.Add($"Course {i}", DateTime.Today, DateTime.Today.AddDays(i*2));
                Course course = Course.Get($"Course {i}");
                Assignment.Add($"Assignment {i}", DateTime.Today, DateTime.Today.AddDays(i * 2));
                Assignment assignment = Assignment.Get($"Assignment {i}");
                Trainer trainer = new Trainer($"Al Trainer {i}", $"Pl Trainer {i}", 30, "Male", DateTime.Today);
                Student student = new Student($"Al Trainer {i}", $"Pl Trainer {i}", 30, "Male", DateTime.Today);
                for(int j=i-1; j>=0; j--)
                {
                    course.Assignments.Add(Assignment.Assignments[j]);
                    course.Trainers.Add(Trainer.Trainers[j]);
                    course.Students.Add(Student.Students[j]);
                    Student.Students[j].Courses.Add(course);
                    assignment.Courses.Add(Course.Courses[j]);
                    assignment.Students.Add(Student.Students[j]);
                    student.Assignments.Add(Assignment.Assignments[j]);
                }
            }
            
        }
        

        
    }
}
