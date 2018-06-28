using System.ComponentModel.DataAnnotations;

namespace SennoAPI.DTO
{
    /// <summary>
    /// API token
    /// </summary>
    public class SennoApiToken
    {
        public int Id { get; set; }

        [Required]
        public string AccessToken { get; set; }
    }
}
