using System.Diagnostics;

namespace CoreSchool.Models
{   
    [DebuggerDisplay("{StudentName} {GetNotesString()}")]
    public class Score: Entity
    {
        private float[] note = new float[5];

        public string ScoreId { get; set; }
        public string StudentName { get; set; }
        public string AssignmentName { get; set; }
        public float[] Notes { get => note; set => note = value; }

        private string GetNotesString()
        {
            string chain = "| ";
            foreach (var note in Notes)
            {
                chain += $"{note} | ";
            }
            return chain;
        }

        public float GetAverage()
            => Notes.Sum() / Notes.Count();
               

        public override string ToString()
            => $"Student: {StudentName}\nAssignment: {AssignmentName}\nNotes: {GetNotesString()}";
    }
}