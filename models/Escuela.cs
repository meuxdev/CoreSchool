namespace CoreSchool.Models
{
    class School
    {
        string name;

        public string Name
        {
            get { return "Name School -> " + this.name; }
            set { this.name = value.ToUpper(); }
        }

        public int FoundationYear{ get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public TypesSchool Type { get; set; }

        public School(string name, int foundationYear)
            => (Name, FoundationYear) = (name, foundationYear);

        public override string ToString()
        {
            return $"{Name}\nType School -> {Type}\nFoundation Year -> {FoundationYear}\nCountry -> {Country}\nCity -> {City}" ;
        }

    }

}

