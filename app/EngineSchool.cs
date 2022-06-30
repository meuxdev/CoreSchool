using CoreSchool.Models;
using CoreSchool.Util;

namespace CoreSchool
{
    class EngineSchool
    {
        private School school = new School();

        public School School { get => school; private set => school = value; }


        public EngineSchool()
        {
        }

        public void Init()
        {
            Printer.WriteTitle("Initializing the School with default information...");
            Demo.InitCourses(ref this.school);

            Random rnd = new Random();
            foreach (Course course in this.school.Courses)
            {
                Demo.InitStudents(course, rnd.Next(5, 20));
                Demo.InitAssignments(course);
                Demo.InitScore(course);
            }
        }


    }
}