namespace CoreSchool.Models
{
    public class Score
    {
        private float[] note = new float[5];

        public string ScoreId { get; set; }
        public string StudentName { get; set; }
        public string AssignmentName { get; set; }
        public float[] Notes { get => note; set => note = value; }
        public Score() => ScoreId = Guid.NewGuid().ToString();

        private string GetNotesString()
        {
            string chain = "| ";
            foreach (var note in Notes)
            {
                chain += $"{note} | ";
            }
            return chain;
        }
        public override string ToString()
            => $"Student: {StudentName}\nAssignment: {AssignmentName}\nNotes: {GetNotesString()}";
    }
}