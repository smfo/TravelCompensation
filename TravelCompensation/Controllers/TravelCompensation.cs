using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using TravelCompensation.Services.Interfaces;
using TravelCompensation.Services;
using TravelCompensation.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace TravelCompensation
{
    public class TravelCompensation
    {

        public ITravelCompensationService CompensationService;

        public TravelCompensation()
        {
            CompensationService = new TravelCompensationService();
        }

        public APIGatewayProxyResponse Get(APIGatewayProxyRequest requeste)
        {

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = CompensationService.CalculateCompensation(new Compensation()).ToString(),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }
}
