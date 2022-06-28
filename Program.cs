using System;
using CoreSchool.Models;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Random School", 2012);
            school.Country = "Random Country";
            school.City = "Random City";
            school.Type = TypesSchool.Online;
            School school1 = new School("Random Name",
                                           1998,
                                           TypesSchool.Degree,
                                           city: "Random City"
                                           );
            Console.WriteLine(school);
            Console.WriteLine(school1);

        }
    }

}
