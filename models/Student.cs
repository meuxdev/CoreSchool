using CoreSchool.Util;

namespace CoreSchool.Models
{
    public class Student : Entity
    {
        public Student() => Id = Guid.NewGuid().ToString();

        public static void InitDemoStudents(Course course)
        {
            // Init with default random students names.
        }

        public override string ToString()
            => Printer.GetLine(30) + ($"\nStudent Name: {Name}\n Student ID: {Id}");
    }
}