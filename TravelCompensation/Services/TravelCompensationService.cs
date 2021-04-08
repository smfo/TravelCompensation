using System.Collections.Generic;
using TravelCompensation.Models;
using TravelCompensation.Services.Interfaces;

namespace TravelCompensation.Services
{
    public class TravelCompensationService : ITravelCompensationService
    {

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

            double travelCompensation = totalTravelCosts >= Config.EXCESS ? totalTravelCosts - Config.EXCESS : 0;

            return new List<double> { travelCompensation, totalTravelCosts };
        }

        private double TollCost(double tollExpenses)
        {
            return tollExpenses >= Config.LOWER_TOLL_LIMIT ? tollExpenses : 0;
        }

        private double TravelCosts(List<Travel> travels)
        {
            double totalTravelCosts = 0;

            foreach (Travel travel in travels)
            {
                double costPerTrip;
                List<double> distances = CalculateDistancesToCompensate(travel);

                costPerTrip = distances[0] * Config.LOWER_DISTANCE_COMPENSATION + distances[1] * Config.HIGHER_DISTANCE_COMPENSATION;

                totalTravelCosts += costPerTrip * travel.NumberOfTrips;
            }

            return totalTravelCosts;
        }

        private List<double> CalculateDistancesToCompensate(Travel travel)
        {
            double lowCompensationDistance;
            double highCompensationDistance;

            double distance = travel.Distance;
            if (distance > Config.MAX_DISTANCE_IN_KM)
            {
                distance = Config.MAX_DISTANCE_IN_KM;
            }

            if (distance <= Config.LOWER_DISTANCE_LIMIT_IN_KM)
            {
                lowCompensationDistance = distance;
                highCompensationDistance = distance - lowCompensationDistance;
            }
            else
            {
                lowCompensationDistance = Config.LOWER_DISTANCE_LIMIT_IN_KM;
                highCompensationDistance = 0;
            }

            List<double> distances = new List<double> { lowCompensationDistance, highCompensationDistance };

            return distances;
        }
    }

    public static class Config
    {
        public const int MAX_DISTANCE_IN_KM = 75000;
        public const int LOWER_DISTANCE_LIMIT_IN_KM = 50000;
        public const double LOWER_DISTANCE_COMPENSATION = 1.5;
        public const double HIGHER_DISTANCE_COMPENSATION = 0.7;

        public const int LOWER_TOLL_LIMIT = 3400;

        public const int EXCESS = 22000;
    }
}
