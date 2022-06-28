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

        public int FoundationYear { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public TypesSchool Type { get; set; }

        public School(
                string name, 
                int foundationYear,
                TypesSchool type=TypesSchool.Default)
            => (Name, FoundationYear) = (name, foundationYear);

        public School(string name,
                     int foundationYear,
                     TypesSchool type,
                     string country = "Default Country",
                     string city = "Default City")
        {
            (Name, FoundationYear) = (name, foundationYear);
            (Country, City) = (country, city);
            Type = type;
        }

        public override string ToString()
        {
            return $"---------------\n{Name}\nType School -> {Type}\nFoundation Year -> {FoundationYear}\nCountry -> {Country}\nCity -> {City}\n----------------";
        }

    }

}

