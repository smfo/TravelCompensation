using System;
using System.Collections.Generic;
using System.Text;
using TravelCompensation.Models;

namespace TravelCompensation.Services.Interfaces
{
    public interface ITravelCompensationService
    {
        public List<double> CalculateCompensation(TravelExpenses compensation);
    }
}
