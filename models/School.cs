using CoreSchool.Util;
using static System.Console;

namespace CoreSchool.Models
{
    public class School : Entity
    {
        string name;
        private List<Course> courses = new List<Course>();

        public string Name
        {
            get { return "School -> " + this.name; }
            set { this.name = value.ToUpper(); }
        }

        public int FoundationYear { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public TypesSchool Type { get; set; }

        public List<Course> Courses { get => courses; private set => courses = value; }

        public School(string name = "Default Name School",
                     int foundationYear = 0,
                     TypesSchool type = TypesSchool.Default,
                     string country = "Default Country",
                     string city = "Default City")
        {
            Name = name;
            FoundationYear = foundationYear;
            type = Type;
            (Country, City) = (country, city);
            Id = Guid.NewGuid().ToString();
        }

        public void PrintCourses()
        {
            string title = $"Courses for  {Name}";
            Printer.WriteTitle(title);
            if (Courses.Count > 0)
            {
                foreach (Course course in Courses)
                {
                    WriteLine(course);
                }
            }
            else
            {
                WriteLine("Empty Courses...");
            }
            Printer.DrawLine(length: title.Length);
        }

        public (bool, Course) RemoveCourseByRef(Course course)
            => (courses.Remove(course), course);

        public void RemoveByName(string name)
             => courses.RemoveAll(course => course.Name == name);

        public void RemoveByNameAndSchedule(string name, TypesSchedule schedule)
            => courses.RemoveAll(course => course.Name == name && course.Schedule == schedule);

        public void AddCourse(Course newCourse)
            => courses.Add(newCourse);

        public void AddCourses(List<Course> newCourses)
            => courses.AddRange(newCourses);
        public void PrintAllStudents()
        {
            foreach (Course c in Courses)
            {
                c.PrintStudents();
            }
        }

        public void PrintAllAssignments()
        {
            foreach (Course c in Courses)
            {
                c.PrintAssignments();
            }
        }

        public override string ToString()
        {
            string chain = Printer.GetLine(length: 100);
            chain += $"\n{Name}\nType School -> {Type}\nFoundation Year -> {FoundationYear}\nCountry -> {Country}\nCity -> {City}\n";
            chain += Printer.GetLine(length: 100);
            return chain;
        }

    }

}

