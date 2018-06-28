using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SennoAPI.Attributes;
using SennoAPI.Authentication;
using SennoAPI.DTO;
using SennoAPI.Services;

namespace SennoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Report")]
    public class ReportController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ReportController> _logger;
        public ReportService ReportService { get; set; }

        public ReportController(ReportService reportService, IConfiguration configuration, ILogger<ReportController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            ReportService = reportService;
        }

        /// <summary>
        /// Returns report for provided dates and lexeme
        /// </summary>
        /// <param name="reportInputDto">Data for report generation</param>
        /// <param name="token">Access token</param>
        /// <returns>Report</returns>
        [ProducesResponseType(typeof(IEnumerable<ReportResultDto>), 200)]
        [ProducesResponseType(typeof(ModelStateDictionary), 400)]
        [Authorize(AuthenticationSchemes = TokenAuthenticationHandler.SchemeName)]
        [TypeFilter(typeof(ThrottleAttribute), Arguments = new object[] { 60 })]
        public async Task<IActionResult> GetAsync([FromQuery] ReportInputDto reportInputDto, [FromQuery]string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await ReportService.GetReport(reportInputDto));
        }
    }
}