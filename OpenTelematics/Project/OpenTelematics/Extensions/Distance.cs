using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTelematics.Extensions
{
    public struct Distance : IEquatable<Distance>
    {
        public double Miles { get; private set; }
        public double Kilometres { get; private set; }
        public double Foot { get; private set; }
        public double Yards { get; private set; }
        public double Centimeter { get; private set; }
        public double Metre { get; private set; }

        public Distance(double miles)
        {
            Miles = miles;
            Kilometres = miles * 1.60934;
            Foot = miles * 5280;
            Yards = miles * 1760;
            Centimeter = miles * 160934;
            Metre = miles * 1609.34;
        }

        public bool Equals(Distance other) => 
            (Miles == other.Miles);
        
    }
}
