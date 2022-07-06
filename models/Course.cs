using System;
using System.Diagnostics;
using CoreSchool.Util;

namespace CoreSchool.Models
{
    [DebuggerDisplay("{Name}, {Schedule} {GetType()}")]
    public sealed class Course : Entity, ILocation
    {
        public TypesSchedule Schedule { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Student> Students { get; set; }
        public List<Score> Scores { get; set; }
        string ILocation.Location{ get; set; }

        public Course()
        {
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

        public void PrintScores()
        {
            Printer.WriteTitle($"Scores for the for the course {Name}");
            if (Scores.Count > 0)
            {
                foreach (Score s in Scores)
                {
                    Console.WriteLine(s);
                }

            }
            else
            {
                Printer.WriteTitle("No Scores in this course");
            }
        }

        public void CleanLocation()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning the Location for the course");
            Console.WriteLine($"{Name} course place is now clean");
        }
    }
}