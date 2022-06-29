
namespace CoreSchool.Models
{
    public class Student : Entity
    {
        public Student() => Id = Guid.NewGuid().ToString();
    }
}