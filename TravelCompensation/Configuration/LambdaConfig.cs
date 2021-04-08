﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace TravelCompensation.Configuration
{
    public class LambdaConfig : ILambdaConfig
    {
        public static IConfigurationRoot Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();


        IConfigurationRoot ILambdaConfig.Configuration => Configuration;

    }
}