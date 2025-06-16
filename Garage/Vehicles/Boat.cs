using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public int Length { get; } // Length of the boat in meters

        public Boat(string regNr, string color, int numberOfWheels, int length) : base(regNr, color, numberOfWheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Length: {Length}m";
        }
    }
}
