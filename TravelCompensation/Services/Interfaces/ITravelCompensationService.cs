using System;
using System.Collections.Generic;
using System.Text;
using TravelCompensation.Models;

namespace TravelCompensation.Services.Interfaces
{
    interface ITravelCompensationService
    {
        public double CalculateCompensation(Compensation compensation);
    }
}
