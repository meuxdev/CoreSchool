
using CoreSchool.Util;

namespace CoreSchool.Models
{
    public class Assignment : Entity
    {
        public Assignment() => Id = Guid.NewGuid().ToString();

        public override string ToString()
        {   
            
            return Printer.GetLine(20) + ($"\nAssignment: {Name}\n Assignment ID: {Id}"); 
        }
    }
}