using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCompensation.Models
{
    public class TravelExpenses
    {
        public List<Travel> WorkTrips { get; set; }
        public List<Travel> VisitingTravels { get; set; }
        public int TollExpenses { get; set; }
    }
}
