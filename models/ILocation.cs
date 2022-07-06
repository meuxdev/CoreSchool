using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSchool.Models
{
    // Interface is like a contract the classes implementing
    // the interface should implement the properties and 
    // functions.
    public interface ILocation
    {
        // All props should be public
        public string Location { get; set; }
        public void CleanLocation();
    }
}