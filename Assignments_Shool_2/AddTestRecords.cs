using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_Shool_2
{
    class AddTestRecords
    {
        public School school { get; set; }

        public AddTestRecords(School school)
        {
            this.school = school;
        }

        public void AddRecords()
        {
            for(int i = 0; i < 30; i++)
            {
                Course course = new Course($"Course {i}", i, this.school);
                Assignment assignment = new Assignment($"Assignment {i}", i, this.school);
                Trainer trainer = new Trainer($"Trainer {i}", i, this.school);
                Student student = new Student($"Trainer {i}", i, this.school);
                for(int j=i-1; j>=0; j--)
                {
                    course.Assignments.Add(this.school.Assignments[j]);
                    course.Trainers.Add(this.school.Trainers[j]);
                    course.Students.Add(this.school.Students[j]);
                    this.school.Students[j].Courses.Add(course);
                    student.Assignments.Add(this.school.Assignments[j]);
                }
                this.school.Courses.Add(course);
                this.school.Assignments.Add(assignment);
                this.school.Trainers.Add(trainer);
                this.school.Students.Add(student);
            }
            
        }
        

        
    }
}
