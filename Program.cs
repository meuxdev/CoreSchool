using System;
using CoreSchool.Models;
using CoreSchool.Util;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineSchool eng = new EngineSchool();
            eng.Init();

            Course newCourse = new Course()
            {
                Name = ".NET 2018",
                Schedule = TypesSchedule.Morning
            };

            eng.School.AddCourse(newCourse);
            eng.School.PrintCourses();
            eng.School.PrintAllStudents();
            eng.School.PrintAllAssignments();
            eng.School.PrintAllScores();


            Printer.EnterPause();
        }
    }

}
