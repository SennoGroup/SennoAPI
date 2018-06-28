using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Serilog.Events;

namespace SennoAPI.Extensions
{
    public static class MapperConfigurationExtensions
    {
        public static IMapperConfigurationExpression CreateMappingsForLogs(
            this IMapperConfigurationExpression configuration)
        {
            //omitted for brevity
            return configuration;
        }

        public static IMapperConfigurationExpression CreateMappingsForDomainModels(
            this IMapperConfigurationExpression configuration)
        {
            //omitted for brevity
            return configuration;
        }
    }
}
