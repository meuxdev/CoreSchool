using CoreSchool.Models;
using CoreSchool.Util;

namespace CoreSchool
{
    class EngineSchool
    {
        private School school = new School();

        public School School { get => school; private set => school = value; }


        public EngineSchool()
        {
        }

        public void Init()
        {
            Printer.WriteTitle("Initializing the School with default information...");
            Course.InitDemoCourses(ref this.school);
        }
    }
}