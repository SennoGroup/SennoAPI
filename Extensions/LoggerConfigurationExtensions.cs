using System;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace SennoAPI.Extensions
{
    public static class LoggerConfigurationExtensions
    {
        public static ILogger CreateLoggerFromConfiguration(this LoggerConfiguration loggerConfiguration,
            IConfiguration configuration, IServiceProvider serviceProvider)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }
    }
}
