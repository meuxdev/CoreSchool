using CoreSchool.Models;

namespace CoreSchool.Util
{
    public class Demo
    {
        public static void InitCourses(ref School school)
        {
            // Init demo for courses
            List<Course> courses = new List<Course>(){
                new Course(){
                    Name = "Python Basic Course",
                    Schedule = TypesSchedule.Morning
                },
                new Course(){
                    Name = "Java Basic Course",
                    Schedule = TypesSchedule.Night
                },
                new Course(){
                    Name = "Golang Basic Course",
                    Schedule = TypesSchedule.Night
                }
            };


            school.AddCourses(courses);
        }

        public static void InitStudents(Course course, int groupSize)
        {
            string[] name = { "Freddy", "Alex", "Jorge", "Josh", "Chris" };
            string[] middleName = { "Felix", "John", "Robert", "Samuel", "Rick" };
            string[] lastName = { "Ruiz", "Trump", "Toledo", "Herrera" };

            IEnumerable<Student> query = from n in name
                               from mn in middleName
                               from l in lastName
                               select new Student { Name = $"{n} {mn} {l}" };

            List<Student> students = query.OrderBy(student => student.Id).Take(groupSize).ToList();
            course.AddStudents(students);
        }


        public static void InitAssignments(Course course)
        {
            List<Assignment> assignments = new List<Assignment>(){
                new Assignment(){Name = "History"},
                new Assignment(){Name = "Math"},
                new Assignment(){Name = "Grammar"},
            };
            course.AddAssignments(assignments);
        }
    }
}