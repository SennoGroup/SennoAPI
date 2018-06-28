using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SennoAPI.Attributes;
using SennoAPI.Authentication;
using SennoAPI.DTO;
using SennoAPI.Extensions;
using SennoAPI.Services;

namespace SennoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/FacialEmotionReport")]
    public class FacialEmotionReportController : Controller
    {
        private readonly ILogger<FacialEmotionReportController> _logger;
        private readonly IConfiguration _configuration;
        public FacialAnalysisService ReportService { get; set; }

        public FacialEmotionReportController(FacialAnalysisService reportService,
          ILogger<FacialEmotionReportController> logger,
          IConfiguration configuration)
        {
            _logger = logger;
            ReportService = reportService;
            _configuration = configuration;
        }

        /// <summary>
        /// Gives Facial Emotion report based on provided url
        /// </summary>
        /// <param name="reportInput">Data for analysis</param>
        /// <param name="token">Access token</param>
        /// <returns>Emotion Scores</returns>
        [Authorize(AuthenticationSchemes = TokenAuthenticationHandler.SchemeName)]
        [TypeFilter(typeof(ThrottleAttribute), Arguments = new object[] { 60 })]
        [ProducesResponseType(typeof(List<EmotionScore>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAsync([FromQuery] FacialAnalysisInput reportInput, [FromQuery]string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var facialAnalysisResult = await ReportService.ProcessImageAsync(reportInput.ImageUrl);

                if (!facialAnalysisResult.FaceIsFound)
                {
                    return BadRequest(Constants.FACE_NOT_FOUND);
                }

                return Ok(facialAnalysisResult.EmotionScores);
            }
            catch (Exception e)
            {
                _logger.LogError(e, Constants.FACIAL_RECOGNITION_ERROR);

                return BadRequest(Constants.GENERAL_ERROR);
            }
        }
    }
}