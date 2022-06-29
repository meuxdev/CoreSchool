using System;

namespace CoreSchool.Models
{
    public class Course
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public TypesSchedule Schedule{ get; set; }

        public Course()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            string chain = "---------------\n";
            chain += $"Course ID: {Id}\n";
            chain += $"Course Name: {Name}\n";
            chain += "---------------------\n";
            return chain;
        }
    }
}