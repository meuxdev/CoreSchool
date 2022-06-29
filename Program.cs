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

            Course.InitDemoCourses(ref school1);

            Course tmpCourse = new Course(){
                Name = "Summer Course",
                Schedule = TypesSchedule.Morning
            };

            school1.AddCourse(tmpCourse);
            school1.PrintCourses();
            school1.RemoveCourseByRef(tmpCourse);
            school1.PrintCourses();
            school1.RemoveByName("Golang Basic Course");
            school1.PrintCourses();

        }
    }

}
