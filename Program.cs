using System;
using CoreSchool.Models;
using CoreSchool.Util;
using static System.Console;

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
            // eng.School.PrintCourses();
            // eng.School.PrintAllStudents();
            // eng.School.PrintAllAssignments();
            // eng.School.PrintAllScores();
            List<Entity> objs = eng.GetObjEntity();
            WriteLine(objs.Count());

            foreach(Entity ob in objs)
            {
                if(ob is Assignment){
                    WriteLine(ob);
                }
            }
            
            Printer.EnterPause();
        }
    }

}
