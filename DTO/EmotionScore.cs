namespace SennoAPI.DTO
{
    public class EmotionScore
    {
        /// <summary>
        /// Emotion name
        /// </summary>
        public string Emotion { get; set; }
        /// <summary>
        /// Emotion score
        /// </summary>
        public decimal ScoreInPercentage { get; set; }
    }
}
