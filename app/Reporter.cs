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
            if( dic is null)
                throw new ArgumentNullException(nameof(dic));
            
            _dic = dic;
        }


        public IEnumerable<Score> GetScoresList()
        {
            // var list = _dic.GetValueOrDefault(KeysDicEnum.School);
            var response = _dic.TryGetValue(KeysDicEnum.Scores, 
                out IEnumerable<Entity> list
            );

            if(!response){
                // throw new KeyNotFoundException($"{KeysDicEnum.School} not registered on the dictionary");
                return new List<Score>();
            }

            return list.Cast<Score>();
        }

        public IEnumerable<string> GetAssignmentsList() 
        {
            IEnumerable<Score> listScores = GetScoresList();

            return (from Score s in listScores
                   where s.Notes.Sum() > 3.0f
                   select s.AssignmentName).Distinct();
        }


        public Dictionary<string, Score> GetAssignmentAndScore()
        {
            var dic = new Dictionary<string, Score>();

            return dic;
        }
        
    }
}