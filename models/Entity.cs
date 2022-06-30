namespace CoreSchool.Models
{
    public abstract class Entity
    {
        private string name;
        public string Id { get; set; }
        public string Name { get => name; set => name = value; }

    }
}