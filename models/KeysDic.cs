using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSchool.Models
{
    // struct -> is more simple for native vars in this case is better to use an struct.
    public struct KeysDic
    {
        public const string STUDENTS_KEY = "STUDENTS";
        public const string SCHOOLS_KEY = "SCHOOLS";
        public const string ASSIGNMENT_KEY = "ASSIGNMENT";
        public const string SCORES_KEY = "SCORES";
        public const string COURSES_KEY = "COURSES";
    }

    public enum KeysDicEnum 
    {
        Courses,
        Students,
        Assignments,
        Scores,
        School
    }
}