using System;

namespace SennoAPI.DTO
{
    public class ReportResultDto
    {
        public ReportResultDto(ReportItem r)
        {
            //omitted for brevity
        }

        /// <summary>
        /// Result buzz
        /// </summary>
        public int Buzz { get; set; }

        /// <summary>
        /// Result Mood
        /// </summary>
        public int Mood { get; set; }

        /// <summary>
        /// Report date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
