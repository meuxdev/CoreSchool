namespace CoreSchool.Models
{
    public class Califications : Entity
    {
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public float Calification { get; set; }
        public Califications() => Id = Guid.NewGuid().ToString();
    }
}