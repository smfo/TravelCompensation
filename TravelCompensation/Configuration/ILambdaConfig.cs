using Microsoft.Extensions.Configuration;

namespace TravelCompensation.Configuration
{
    public interface ILambdaConfig
    {
        IConfiguration Configuration { get; }
    }
}
