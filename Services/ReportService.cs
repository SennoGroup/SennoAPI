using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SennoAPI.DTO;
using SennoAPI.Extensions;

namespace SennoAPI.Services
{
    public class ReportService
    {
        public IAnalysisService AnalysisService { get; set; }

        public ReportService(IAnalysisService analysisService)
        {
            AnalysisService = analysisService;
        }

        public async Task<IEnumerable<ReportResultDto>> GetReport(ReportInputDto reportInput)
        {
            var lexeme = GetLexeme(reportInput.Lexeme);
            var language = GetLanguage(reportInput.LanguageId);

            if (lexeme == null)
                return new List<ReportResultDto>();

            var fromDate = reportInput.FromDate.StartOfDay();
            var toDate = reportInput.ToDate.EndOfDay();

            var reportDates = SplitReport(fromDate, toDate);
            var existingReportItems = AnalysisService.LoadExistingReportItems(fromDate, toDate, lexeme, language);

            var reportItems = new List<ReportItem>();
            foreach (var reportDate in reportDates)
            {
                var existing = existingReportItems.Where(ri => ri.FromDate == reportDate);
                if (existing.Any())
                {
                    reportItems.AddRange(existing);
                }
                else
                {
                    var newReportItems = await AnalysisService.GenerateReportAsync(reportDate, lexeme, language);
                    reportItems.AddRange(AnalysisService.SaveReportItems(newReportItems));
                    ;
                }
            }

            reportItems = reportItems.OrderBy(ri => ri.FromDate).ToList();

            return reportItems.Select(r => new ReportResultDto(r));
        }

        private Language GetLanguage(int reportInputLanguageId)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }

        private Lexeme GetLexeme(string reportInputLexeme)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }

        /// <summary>
        /// Split the report period on intervals according to current configuration (for instance, per day)
        /// </summary>
        /// <returns>All date ranges for report</returns>
        private IEnumerable<DateTime> SplitReport(DateTime fromDate, DateTime toDate)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }
    }

    
}
