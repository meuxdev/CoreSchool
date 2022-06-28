namespace CoreSchool.Models
{
    class School
    {
        string name;

        public string Name
        {
            get { return "Copy: " + this.name; }
            set { this.name = value.ToUpper(); }
        }

        public int FoundationYear{ get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public School(string name, int foundationYear)
            => (Name, FoundationYear) = (name, foundationYear);

    }

}

