using static System.Console;

namespace CoreSchool.Models
{
    public class School
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

        public School(
                string name = "Default Test School",
                int foundationYear = 0,
                TypesSchool type = TypesSchool.Default)
            => (Name, FoundationYear) = (name, foundationYear);

        public School(string name,
                     int foundationYear,
                     TypesSchool type,
                     string country = "Default Country",
                     string city = "Default City")
        {
            (Name, FoundationYear) = (name, foundationYear);
            (Country, City) = (country, city);
            Type = type;
        }

        public void PrintCourses()
        {
            WriteLine("=========================================");
            WriteLine($"Courses for  {Name}\n");
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
            WriteLine("=========================================");
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

        public override string ToString()
        {
            return $"---------------\n{Name}\nType School -> {Type}\nFoundation Year -> {FoundationYear}\nCountry -> {Country}\nCity -> {City}\n----------------";
        }

    }

}

