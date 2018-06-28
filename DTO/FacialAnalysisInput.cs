using System.ComponentModel.DataAnnotations;

namespace SennoAPI.DTO
{
    public class FacialAnalysisInput
    {
        /// <summary>
        /// Url path to image
        /// </summary>
        [Required]
        public string ImageUrl { get; set; }
    }
}
