using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCompensation.Models
{
    public interface Travel
    {
        double Distance { get; set; }
        int NumberOfTrimps { get; set; }
    }
}
