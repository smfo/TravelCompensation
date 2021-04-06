using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCompensation.Models
{
    public interface Compensation
    {
        Travel[] WorkTrips { get; set; }
        Travel[] VisitingTravels { get; set; }
        int ToolExpenses { get; set; }
    }
}
