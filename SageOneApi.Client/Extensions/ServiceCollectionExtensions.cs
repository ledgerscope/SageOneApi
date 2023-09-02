using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ServiceCollection AddSageOneApi(this ServiceCollection services)
        {
            services.AddSingleton<SageOneApiClientConfig>((a) => SageOneApiClientConfig.Default); 
            return services;
        }
    }
}
