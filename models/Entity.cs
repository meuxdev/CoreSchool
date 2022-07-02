namespace CoreSchool.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Entity()
            => Id = Guid.NewGuid().ToString();
    }
}