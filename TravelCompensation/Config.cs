using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCompensation
{
    public class Config
    {
        public int MAX_DISTANCE_IN_KM = 75000;
        public int LOWER_DISTANCE_LIMIT_IN_KM = 50000;
        public double LOWER_DISTANCE_COMPENSATION = 1.5;
        public double HIGHER_DISTANCE_COMPENSATION = 0.7;

        public int LOWER_TOLL_LIMIT = 34000;

        public int EXCESS = 22000;
    }
}
