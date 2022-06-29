using CoreSchool.Models;

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
            Course.InitDemoCourses(ref this.school);
        }
    }
}