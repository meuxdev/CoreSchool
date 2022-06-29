using System;
using CoreSchool.Models;
using CoreSchool.Util;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.MakeBeep();
            EngineSchool eng = new EngineSchool();
            eng.Init();

            Course newCourse = new Course(){
                Name = ".NET 2018",
                Schedule = TypesSchedule.Morning
            };

            eng.School.AddCourse(newCourse);
            eng.School.PrintCourses();
            Console.WriteLine("ENTER to continue ...");
            Console.ReadLine();
        }
    }

}
