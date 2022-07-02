
using CoreSchool.Util;
using System.Diagnostics;

namespace CoreSchool.Models
{
    [DebuggerDisplay("{Name}")]
    public class Assignment : Entity
    {
        public override string ToString()
        {
            return Printer.GetLine(20) + ($"\nAssignment: {Name}\n Assignment ID: {Id}");
        }
    }
}