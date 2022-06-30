using System;
using CoreSchool.Util;

namespace CoreSchool.Models
{
    public class Course : Entity
    {
        public TypesSchedule Schedule { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Student> Students { get; set; }

        public List<Score> Scores { get; set; }

        public Course()
        {
            Id = Guid.NewGuid().ToString();
            Students = new List<Student>();
            Assignments = new List<Assignment>();
            Scores = new List<Score>();
        }

        public override string ToString()
        {
            string chain = Printer.GetLine(length: 70) + "\n";
            chain += $"     Course ID: {Id}\n";
            chain += $"     Course Name: {Name}\n";
            chain += $"     Course Schedule: {Schedule}\n";
            return chain;
        }

        public void AddStudents(List<Student> students)
            => Students.AddRange(students);

        public void AddAssignments(List<Assignment> assignments)
            => Assignments.AddRange(assignments);

        public void AddStudent(Student student)
            => Students.Add(student);
        public void AddAssignment(Assignment assignment)
            => Assignments.Add(assignment);
        
        public void LoadScores(List<Score> scores)
            => Scores.AddRange(scores);

        public void PrintStudents()
        {
            Printer.WriteTitle($"Students for the course {Name}");
            if (Students.Count > 0)
            {
                foreach (Student s in Students)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Printer.WriteTitle("No students in this course");
            }
        }

        public void PrintAssignments()
        {
            Printer.WriteTitle($"Assignments for the course {Name}");
            if (Students.Count > 0)
            {
                foreach (Assignment a in Assignments)
                {
                    Console.WriteLine(a);
                }
            }
            else
            {
                Printer.WriteTitle("No Assignments in this course");
            }
        }
    }
}