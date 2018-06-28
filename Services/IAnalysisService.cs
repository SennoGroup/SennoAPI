using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SennoAPI.DTO;

namespace SennoAPI.Services
{
    public interface IAnalysisService
    {
        IEnumerable<ReportItem> LoadExistingReportItems(DateTime fromDate, DateTime toDate, Lexeme lexeme, Language language);
        Task<IEnumerable<ReportItem>> GenerateReportAsync(DateTime reportDate, Lexeme lexeme, Language language);
        IEnumerable<ReportItem> SaveReportItems(IEnumerable<ReportItem> newReportItems);
    }
}
