using System;
using CoreSchool.Models;

namespace Stage1
{
    class Program
    {
        static void Main(string[] args)
        {
             var school = new School("Random School", 2012);
             school.Country =  "Random Country";
             school.City = "Random City";
             Console.WriteLine(school.Name);

        }
    }

}
