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
using Newtonsoft.Json;

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

        public APIGatewayProxyResponse Get(LambdaRequest requeste)
        {
            Compensation travelExpenses = JsonConvert.DeserializeObject<Compensation>(requeste.Body);

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = CompensationService.CalculateCompensation(travelExpenses).ToString(),
            };

            return response;
        }
    }
}
