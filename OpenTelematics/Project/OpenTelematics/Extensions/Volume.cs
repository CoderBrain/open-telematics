using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTelematics.Extensions
{
    public struct Volume : IEquatable<Volume>
    {
        public decimal Litres { get; private set; }
        public decimal Milelitres { get; private set; }

        public Volume(decimal litres)
        {
            Litres = litres;
            Milelitres = (litres * 1000); 
        }

        public bool Equals(Volume other) => 
            (other.Litres == Litres);
    }
}
