namespace Portfolio.Models
{
    public class HighScoreModel
    {
        public string? PlayerName { get; set; }

        public int? PlayerScore { get; set; }

        public HighScoreModel(string name, int score)
        {
            PlayerName= name;
            PlayerScore= score;
        }
    }
}