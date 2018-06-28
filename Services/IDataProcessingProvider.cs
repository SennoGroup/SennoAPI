using System.Threading.Tasks;
using SennoAPI.DTO;

namespace SennoAPI.Services
{
    public interface IDataProcessingProvider
    {
        Task<FacialAnalysisResult> ProcessMediaAsync(string mediaUrl);
    }
}
