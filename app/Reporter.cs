using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSchool.Models;



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

            foreach(KeyValuePair<string, IEnumerable<Score>> assignByScore in dicAssignScores)
            {
                var avgStudent = from eval in assignByScore.Value
                            select new FinalGrade {
                                            StudentName = eval.StudentName,
                                            Avg = eval.Notes.Sum() / eval.Notes.Count(),
                                            Name = eval.Name,
                                            Id = eval.Id
                                        };
                dic.Add(assignByScore.Key , avgStudent);
            }
            return dic;
        }
    }
}