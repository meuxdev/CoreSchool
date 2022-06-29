namespace CoreSchool.Models
{
    public class Entity
    {
        private string name;

        public string Id { get; set; }
        public string Name { get => name; set => name = value; }
    }
}