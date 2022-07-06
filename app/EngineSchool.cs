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

        public List<Entity> GetObjEntity(
            out int countScores,
            out int countStudents,
            out int countAssigns,
            out int countCourses,
            bool getScores = true,
            bool getStudents = true,
            bool getAssignments = true,
            bool getCourses = true
        )
        {
            List<Entity> listObj = new List<Entity>();
            countScores = countStudents = countAssigns = 0;

            listObj.Add(School);

            if (getCourses)
            {
                listObj.AddRange(School.Courses);
            }


            countCourses = school.Courses.Count;
            foreach (var course in School.Courses)
            {
                if (getAssignments)
                {
                    listObj.AddRange(course.Assignments);
                    countAssigns += course.Assignments.Count;
                }

                if (getStudents)
                {
                    listObj.AddRange(course.Students);
                    countStudents += course.Students.Count;
                }

                if (getScores)
                {
                    listObj.AddRange(course.Scores);
                    countScores += course.Scores.Count;
                }
            }
        return listObj;
        }
    }
}