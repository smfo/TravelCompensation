using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCompensation.Models
{
    public class TravelExpenses
    {
        public Travel[] WorkTrips { get; set; }
        public Travel[] VisitingTravels { get; set; }
        public int ToolExpenses { get; set; }
    }
}
