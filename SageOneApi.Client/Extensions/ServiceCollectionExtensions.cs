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
        public static T AddSageOneApi<T>(this T services) where T : IServiceCollection
        {
            services.AddSingleton<SageOneApiClientConfig>((a) => SageOneApiClientConfig.Default);
            services.AddHttpClient();
            return services;
        }
    }
}
