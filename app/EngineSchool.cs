using CoreSchool.Models;
using CoreSchool.Util;

namespace CoreSchool.App
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

        public IReadOnlyList<Entity> GetObjEntity(
                    bool getScores = true,
                    bool getStudents = true,
                    bool getAssignments = true,
                    bool getCourses = true
                )
        {
            return GetObjEntity(out int _d, out _d, out _d, out _d);
        }

        public Dictionary<KeysDicEnum, IEnumerable<Entity>> GetObjDictionary()
        {
            var dic = new Dictionary<KeysDicEnum, IEnumerable<Entity>>();


            dic.Add(KeysDicEnum.School, new[] { School });
            dic.Add(KeysDicEnum.Courses, School.Courses.Cast<Entity>());

            var studentList = new List<Student>();
            var scoreList = new List<Score>();
            var assignList = new List<Assignment>();

            foreach (Course c in School.Courses)
            {
                studentList.AddRange(c.Students);
                scoreList.AddRange(c.Scores);
                assignList.AddRange(c.Assignments);
            }

            dic.Add(KeysDicEnum.Students, studentList);
            dic.Add(KeysDicEnum.Scores, scoreList);
            dic.Add(KeysDicEnum.Assignments, assignList);

            return dic;
        }

        public void PrintDic(
            Dictionary<KeysDicEnum, IEnumerable<Entity>> dic,
            bool printScores = false,
            bool printStudents = true,
            bool printAssignments = true,
            bool printCourses = true 
        )
        {
            foreach (KeyValuePair<KeysDicEnum, IEnumerable<Entity>> kv in dic)
            {
                if ((kv.Key == KeysDicEnum.Scores && !printScores) ||
                    (kv.Key == KeysDicEnum.Students && !printStudents) ||
                    (kv.Key == KeysDicEnum.Courses && !printCourses) ||
                    (kv.Key == KeysDicEnum.Assignments && !printAssignments))
                    continue;

                // if (kv.Key == KeysDicEnum.Scores && !printScores)
                //     continue;

                // if (kv.Key == KeysDicEnum.Students && !printStudents)
                //     continue;

                // if (kv.Key == KeysDicEnum.Courses && !printCourses)
                //     continue;

                // if (kv.Key == KeysDicEnum.Assignments && !printAssignments)
                //     continue;

                Printer.WriteTitle(kv.Key.ToString());
                foreach (Entity entity in kv.Value)
                {
                    Console.WriteLine(entity);
                }
            }
        }

        public IReadOnlyList<Entity> GetObjEntity(
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
            return listObj.AsReadOnly();
        }
    }
}