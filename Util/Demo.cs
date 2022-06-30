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

        public static void InitStudents(Course course)
        {
            string[] name = { "Freddy", "Alex", "Jorge", "Josh", "Chris"};
            string[] middleName = { "Felix", "John", "Robert", "Samuel", "Rick"};
            string[] lastName = { "Ruiz","Trump", "Toledo", "Herrera" };

            var listStudents = from n in name 
                                from mn in middleName 
                               from l in lastName
                               select new Student { Name = $"{n} {mn} {l}" };

            List<Student> students = new List<Student>(){
                new Student() { Name = "Josh" },
                new Student() { Name = "Bob" },
                new Student() { Name = "Fred" }
            };
            course.AddStudents(listStudents);
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