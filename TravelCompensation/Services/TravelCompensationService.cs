using System.Collections.Generic;
using TravelCompensation.Models;
using TravelCompensation.Services.Interfaces;

namespace TravelCompensation.Services
{
    public class TravelCompensationService : ITravelCompensationService
    {

        private Config config = new Config();

        public List<double> CalculateCompensation(TravelExpenses expenses)
        {
            double workTripsCost = 0;
            double visitTravelsCost = 0;

            if (expenses.WorkTrips != null)
            {
                workTripsCost = TravelCosts(expenses.WorkTrips);
            }

            if(expenses.VisitingTravels != null)
            {
                visitTravelsCost = TravelCosts(expenses.VisitingTravels);
            }

            double tollsCompensation = TollCost(expenses.TollExpenses);

            double totalTravelCosts = workTripsCost + visitTravelsCost + tollsCompensation;

            double travelCompensation = totalTravelCosts >= config.EXCESS ? totalTravelCosts - config.EXCESS : 0;

            return new List<double> { travelCompensation, totalTravelCosts };
        }

        private double TollCost(double tollExpenses)
        {
            return tollExpenses >= config.LOWER_TOLL_LIMIT ? tollExpenses : 0;
        }

        private double TravelCosts(List<Travel> travels)
        {
            double totalTravelCosts = 0;

            foreach (Travel travel in travels)
            {
                double costPerTrip;
                List<double> distances = CalculateDistancesToCompensate(travel);

                costPerTrip = distances[0] * config.LOWER_DISTANCE_COMPENSATION + distances[1] * config.HIGHER_DISTANCE_COMPENSATION;

                totalTravelCosts += costPerTrip * travel.NumberOfTrips;
            }

            return totalTravelCosts;
        }

        private List<double> CalculateDistancesToCompensate(Travel travel)
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

            List<double> distances = new List<double> { lowCompensationDistance, highCompensationDistance };

            return distances;
        }
    }
}
