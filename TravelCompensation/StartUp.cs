//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using TravelCompensation.Services;
//using TravelCompensation.Services.Interfaces;

//namespace TravelCompensation
//{
//    public class StartUp
//    {
//        //public static IServiceCollection Container => ConfigureServices(LambdaConfiguration.Configuration);

//        private static IServiceCollection ConfigureServices(IConfigurationRoot root)
//        {

//            var services = new ServiceCollection();

//            services.AddTransient<ITravelCompensationService, TravelCompensationService>();

//            return services;
//        }
//    }
//}
