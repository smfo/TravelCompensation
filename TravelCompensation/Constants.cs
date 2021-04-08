using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCompensation
{
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
