using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSchool.Models;
using CoreSchool.Util;



namespace CoreSchool.App
{
    public class DictionaryReporter
    {

        private Dictionary<KeysDicEnum, IEnumerable<Entity>> _dic { get; set; }

        public DictionaryReporter(Dictionary<KeysDicEnum, IEnumerable<Entity>> dic)
        {
            if (dic is null)
                throw new ArgumentNullException(nameof(dic));

            _dic = dic;
        }


        public IEnumerable<Score> GetScoresList()
        {
            // var list = _dic.GetValueOrDefault(KeysDicEnum.School);
            var response = _dic.TryGetValue(KeysDicEnum.Scores,
                out IEnumerable<Entity> list
            );

            if (!response)
            {
                // throw new KeyNotFoundException($"{KeysDicEnum.School} not registered on the dictionary");
                return new List<Score>();
            }

            return list.Cast<Score>();
        }


        public IEnumerable<string> GetAssignmentsList()
        {
            return this.GetAssignmentsList(out IEnumerable<Score> _empty);
        }

        public IEnumerable<string> GetAssignmentsList(
            out IEnumerable<Score> scoresList
        )
        {
            scoresList = GetScoresList();

            return (from Score s in scoresList
                        //    where s.Notes.Sum() > 3.0f
                    select s.AssignmentName).Distinct();
        }


        public Dictionary<string, IEnumerable<Score>> GetAssignmentAndScore()
        {
            var dic = new Dictionary<string, IEnumerable<Score>>();
            var assignList = GetAssignmentsList(out IEnumerable<Score> scoresList);

            foreach (string assign in assignList)
            {
                var evalForAssign = from score in scoresList
                                    where score.AssignmentName == assign
                                    select score;
                dic.Add(assign, evalForAssign);
            }
            return dic;
        }

        public Dictionary<string, IEnumerable<FinalGrade>> GetAvgForStudentByAssign()
        {
            var dic = new Dictionary<string, IEnumerable<FinalGrade>>();
            var dicAssignScores = GetAssignmentAndScore();

            foreach (KeyValuePair<string, IEnumerable<Score>> assignByScore in dicAssignScores)
            {
                var avgStudent = from eval in assignByScore.Value
                                 select new FinalGrade
                                 {
                                     StudentName = eval.StudentName,
                                     Avg = eval.Notes.Sum() / eval.Notes.Count(),
                                     Name = eval.Name,
                                     Id = eval.Id
                                 };
                dic.Add(assignByScore.Key, avgStudent);
            }
            return dic;
        }


        public Dictionary<string, IEnumerable<FinalGrade>> GetTopAvgFinalGrades(int top)
        {
            if (top <= 0)
            {
                throw new ArgumentException($"{nameof(top)} should be greater than 0 --");
            }

            var dic = new Dictionary<string, IEnumerable<FinalGrade>>();

            var dicAssignScores = GetAssignmentAndScore();

            foreach (KeyValuePair<string, IEnumerable<Score>> kp in dicAssignScores)
            {
                var topAvg = (from eval in kp.Value
                              orderby eval.GetAverage() descending
                              select new FinalGrade
                              {
                                  Avg = eval.GetAverage(),
                                  Id = eval.Id,
                                  Name = eval.Name,
                                  StudentName = eval.StudentName
                              }).Take(top);

                dic.Add(kp.Key, topAvg);
            }

            return dic;
        }


        public static void PrintFinalGrades(Dictionary<string, IEnumerable<FinalGrade>> finalGradesDictionary)
        {
            foreach (KeyValuePair<string, IEnumerable<FinalGrade>> kv in finalGradesDictionary)
            {
                Printer.WriteTitle($"Final Grades for {kv.Key}");

                foreach (FinalGrade studentAvg in kv.Value)
                {
                    Console.Write($"✔️ Student: {studentAvg.StudentName} Final Grade: {studentAvg.Avg}\n");
                }
            }
        }
    }
}