using CoreSchool.Models;
using CoreSchool.Util;

namespace CoreSchool
{
    sealed class EngineSchool
    {
        private School school = new School();

        public School School { get => school; private set => school = value; }

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

        public List<Entity> GetObjEntity()
        {
            List<Entity> listObj = new List<Entity>();

            listObj.Add(School);
            listObj.AddRange(School.Courses);

            foreach(var course in School.Courses)
            {
                listObj.AddRange(course.Assignments);
                listObj.AddRange(course.Students);
                listObj.AddRange(course.Scores);
            }

            return listObj;
        }


    }
}