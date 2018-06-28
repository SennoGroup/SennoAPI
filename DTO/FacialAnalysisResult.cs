using System.Collections.Generic;
using System.Linq;

namespace SennoAPI.DTO
{
    public class FacialAnalysisResult
    {
        /// <summary>
        /// Define if face is found on image
        /// </summary>
        public bool FaceIsFound => EmotionScores != null && EmotionScores.Any();

        /// <summary>
        /// List of emotion scores
        /// </summary>
        public List<EmotionScore> EmotionScores { get; set; }
    }
}
