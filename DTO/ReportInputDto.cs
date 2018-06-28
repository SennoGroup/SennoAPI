using System;
using System.ComponentModel.DataAnnotations;

namespace SennoAPI.DTO
{
    public class ReportInputDto
    {
        /// <summary>
        /// Report start date
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Report end date
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Lexeme for report
        /// </summary>
        [Required]
        public string Lexeme { get; set; }

        /// <summary>
        /// Report language
        /// </summary>
        public int LanguageId { get; set; }
    }
}
