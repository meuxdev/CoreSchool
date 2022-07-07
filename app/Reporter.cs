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


        public IEnumerable<School> GetSchoolList()
        {
            // var list = _dic.GetValueOrDefault(KeysDicEnum.School);
            var response = _dic.TryGetValue(KeysDicEnum.School, 
                out IEnumerable<Entity> list
            );

            if(!response){
                throw new KeyNotFoundException($"{KeysDicEnum.School} not registered on the dictionary");
            }

            return list.Cast<School>();
        }
        
    }
}