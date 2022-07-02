using CoreSchool.Util;
using System.Diagnostics;

namespace CoreSchool.Models
{
    [DebuggerDisplay("Student -> {Name} {Id}")]
    public class Student : Entity
    {
        public override string ToString()
            => Printer.GetLine(30) + ($"\nStudent Name: {Name}\n Student ID: {Id}");
    }
}