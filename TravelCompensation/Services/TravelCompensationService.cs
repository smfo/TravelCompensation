using System;
using System.Collections.Generic;
using System.Text;
using TravelCompensation.Models;
using TravelCompensation.Services.Interfaces;

namespace TravelCompensation.Services
{
    public class TravelCompensationService : ITravelCompensationService
    {

        private Config config = new Config();

        public double CalculateCompensation(Compensation compensation)
        {
            if (compensation == null) return 0;

            double workTripsCost = TravelCosts(compensation.WorkTrips);
            double visitTravelsCost = TravelCosts(compensation.VisitingTravels);

            double tollsCosts = TollCost(compensation.ToolExpenses);

            double totalTravelCosts = workTripsCost + visitTravelsCost + tollsCosts;

            double travelCompensation = totalTravelCosts >= config.EXCESS ? totalTravelCosts - config.EXCESS : 0;

            return travelCompensation;
        }

        private double TollCost(double tollExpenses)
        {
            return tollExpenses >= config.LOWER_TOLL_LIMIT ? tollExpenses : 0;
        }

        private double TravelCosts(Travel[] travels)
        {
            double totalTravelCosts = 0;

            foreach(Travel travel in travels)
            {
                double costPerTrip;
                double[] distances = CalculateDistancesToCompensate(travel);

                costPerTrip = distances[0] * config.LOWER_DISTANCE_COMPENSATION + distances[1] * config.HIGHER_DISTANCE_COMPENSATION;

                totalTravelCosts += costPerTrip;
            }

            return totalTravelCosts;
        }

        private double[] CalculateDistancesToCompensate(Travel travel)
        {
            double lowCompensationDistance;
            double highCompensationDistance;

            double distance = travel.Distance;
            if (distance > config.MAX_DISTANCE_IN_KM)
            {
                distance = config.MAX_DISTANCE_IN_KM;
            }

            if (distance <= config.LOWER_DISTANCE_LIMIT_IN_KM)
            {
                lowCompensationDistance = distance;
                highCompensationDistance = distance - lowCompensationDistance;
            }
            else
            {
                lowCompensationDistance = config.LOWER_DISTANCE_LIMIT_IN_KM;
                highCompensationDistance = 0;
            }

            double[] distances = new double[] { lowCompensationDistance, highCompensationDistance };

            return distances;
        }
    }
}
