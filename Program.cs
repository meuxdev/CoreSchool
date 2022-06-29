using System;
using CoreSchool.Models;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Random School", 2012);
            school.Country = "Random Country";
            school.City = "Random City";
            school.Type = TypesSchool.Online;
            School school1 = new School("Random Name",
                                           1998,
                                           TypesSchool.Degree,
                                           city: "Random City"
                                           );

            //! Creating the Courses
            Course pythonCourse = new Course(){
                Name = "Python Basic Course",
                Schedule = TypesSchedule.Morning
            };

            Course javaCourse = new Course() {
                Name = "Java Basic Course",
                Schedule = TypesSchedule.Night
            };

            Course golangCourse = new Course() {
                Name = "Golang Basic Course",
                Schedule = TypesSchedule.Afternoon
            };

            Console.WriteLine(school);
            Console.WriteLine(school1);
            Console.WriteLine("==========");
            Console.WriteLine(golangCourse);
            Console.WriteLine(javaCourse);
            Console.WriteLine(pythonCourse);

        }
    }

}
