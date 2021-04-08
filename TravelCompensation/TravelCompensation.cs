using System.Collections.Generic;
using System.Net;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using TravelCompensation.Services.Interfaces;
using TravelCompensation.Models;
using Newtonsoft.Json;
using TravelCompensation.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace TravelCompensation
{
    public class TravelCompensation
    {

        protected ITravelCompensationService CompensationService;

        public TravelCompensation(ITravelCompensationService serviceProvider)
        {
            CompensationService = serviceProvider;
        }

        public APIGatewayProxyResponse CalculateCompensation(LambdaRequest requeste, ILambdaContext context)
        {
            var response = new APIGatewayProxyResponse();

            if (requeste == null || requeste.Body == null)
            {
                response.StatusCode = (int)HttpStatusCode.NoContent;
                response.Body = "No compensation data provided";
            }
            else
            {
                TravelExpenses travelExpenses = JsonConvert.DeserializeObject<TravelExpenses>(requeste.Body);
                List<double> results = CompensationService.CalculateCompensation(travelExpenses);

                Response responseJson = new Response()
                {
                    TravelCompensation = results[0],
                    TravelExpenses = results[1]
                };

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Body = JsonConvert.SerializeObject(responseJson);
            }

            return response;
        }
    }
}
