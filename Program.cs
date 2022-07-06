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
            IReadOnlyList<Entity> objs = eng.GetObjEntity(
                out int countScores,
                out int countStudents,
                out int countAssigns,
                out int countCourses
            );

            var ILocationList = from obj in objs
                                where obj is ILocation
                                select (ILocation)obj;

            var StudentsList = from obj in objs
                               where obj is Student
                               select (Student)obj;

            foreach (Entity ob in objs)
            {
                if (ob is Assignment)
                {
                    WriteLine(ob);
                }
            }

            // eng.School.CleanLocation();

            Printer.EnterPause();

        }
    }

}
