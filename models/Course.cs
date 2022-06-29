using System;
using CoreSchool.Util;

namespace CoreSchool.Models
{
    public class Course : Entity
    {
        public TypesSchedule Schedule { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Student> Students { get; set; }

        public Course()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            string chain = Printer.GetLine(length: 70) + "\n";
            chain += $"     Course ID: {Id}\n";
            chain += $"     Course Name: {Name}\n";
            chain += $"     Course Schedule: {Schedule}\n";
            return chain;
        }

        public static void InitDemoCourses(ref School school)
        {
            //! Demo function that inits the courses
            // Creating the Courses
            Course pythonCourse = new Course()
            {
                Name = "Python Basic Course",
                Schedule = TypesSchedule.Morning
            };

            Course javaCourse = new Course()
            {
                Name = "Java Basic Course",
                Schedule = TypesSchedule.Night
            };

            Course golangCourse = new Course()
            {
                Name = "Golang Basic Course",
                Schedule = TypesSchedule.Afternoon
            };

            school.Courses.Add(pythonCourse);
            school.Courses.Add(javaCourse);
            school.Courses.Add(golangCourse);
        }
    }
}