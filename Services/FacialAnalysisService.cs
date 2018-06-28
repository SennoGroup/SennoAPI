using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SennoAPI.DTO;

namespace SennoAPI.Services
{
    public class FacialAnalysisService
    {
        public IConfiguration Configuration { get; set; }
        public IDataProcessingProvider DataProcessingProvider { get; set; }

        public FacialAnalysisService(IConfiguration configuration, IDataProcessingProvider provider)
        {
            Configuration = configuration;
            DataProcessingProvider = provider;
        }

        public async Task<FacialAnalysisResult> ProcessImageAsync(string mediaUrl)
        {
            var emotionScores = await DataProcessingProvider.ProcessMediaAsync(mediaUrl);
            var result = new FacialAnalysisResult { EmotionScores = emotionScores.EmotionScores };
            return result;
        }
    }
}
