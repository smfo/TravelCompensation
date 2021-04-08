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

        protected ITravelCompensationService CompensationService;

        public TravelCompensation()
        {
            CompensationService = new TravelCompensationService();
        }

        public APIGatewayProxyResponse CalculateCompensation(LambdaRequest requeste)
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
