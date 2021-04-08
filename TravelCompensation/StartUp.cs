//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using TravelCompensation.Services;
//using TravelCompensation.Services.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelCompensation.Configuration;
using TravelCompensation.Services;
using TravelCompensation.Services.Interfaces;

namespace TravelCompensation
{
    public class StartUp
    {
        public static IServiceCollection Container => ConfigureServices(LambdaConfig.Configuration);

        private static IServiceCollection ConfigureServices(IConfigurationRoot root)
        {

            var services = new ServiceCollection();

            //Wire up all your dependencies here
            //services.Configure<Greeting>(options =>
            //    root.GetSection("greeting").Bind(options));

            services.AddTransient<ITravelCompensationService, TravelCompensationService>();

            return services;
        }
    }

}
