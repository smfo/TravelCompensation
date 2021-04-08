using Microsoft.Extensions.Configuration;

namespace TravelCompensation.Configuration
{
    public interface ILambdaConfig
    {
        IConfigurationRoot Configuration { get; }
    }
}
