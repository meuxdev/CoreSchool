namespace CoreSchool.Models
{
    public class Score
    {
        private float[] note = new float[5];

        public string ScoreId { get; set; }
        public string StudentId { get; set; }
        public string AssignmentId { get; set; }
        public float[] Note { get => note; set => note = value; }
        public Score() => ScoreId = Guid.NewGuid().ToString();
    }
}