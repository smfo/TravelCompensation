using System;
using System.Collections.Generic;
using System.Text;
using TravelCompensation.Models;
using TravelCompensation.Services.Interfaces;

namespace TravelCompensation.Services
{
    public class TravelCompensationService : ITravelCompensationService
    {
        public double CalculateCompensation(Compensation compensation)
        {
            return 50000;
        }
    }
}
