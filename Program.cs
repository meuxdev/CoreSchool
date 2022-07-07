using System;
using CoreSchool.Models;
using CoreSchool.Util;

namespace CoreSchool.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // AppDomain.CurrentDomain.ProcessExit += ExitEventAction;
            // AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.SoundBeep(2000,100000);
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

            // foreach (Entity ob in objs)
            // {
            //     if (ob is Assignment)
            //     {
            //         WriteLine(ob);
            //     }
            // }

            // eng.School.CleanLocation();

            // * Dictionary example
            // Dictionary<int, string> dic = new Dictionary<int, string>();
            // dic.Add(1, "Alejandro");
            // dic.Add(3, "Jorge");

            // foreach(KeyValuePair<int, string> kp in dic)
            // {
            //     Console.WriteLine($"Key: {kp.Key} \nValue: {kp.Value}");
            // }
            // int key = 23;
            // dic[key] = "Coppe";
            // Console.WriteLine($"Key: {key}\n Value: {dic[key]}");

            // Dictionary<KeysDicEnum, IEnumerable<Entity>> dic = eng.GetObjDictionary();
            var dic = eng.GetObjDictionary();

            // Console.WriteLine("Dict build completed!");
            // eng.PrintDic(dic, printScores: true, printAssignments: false, printStudents: false, printCourses: false);

            var dr = new DictionaryReporter(dic);
            var evalList = dr.GetScoresList();
            var assignGT3 = dr.GetAssignmentsList();
            var evalListWithAssign = dr.GetAssignmentAndScore();
            var averageAssign = dr.GetAvgForStudentByAssign();
            var topAverageStudents = dr.GetTopAvgFinalGrades(3);

            DictionaryReporter.PrintFinalGrades(averageAssign);
            DictionaryReporter.PrintFinalGrades(topAverageStudents);

            Printer.EnterPause();

            
        }

        private static void ExitEventAction(object? sender, EventArgs e)
        {
            Printer.WriteTitle("Exiting....");
            Printer.SoundBeep(3000, 1000, 3);
            Printer.WriteTitle("Bye!");
        }
    }

}
