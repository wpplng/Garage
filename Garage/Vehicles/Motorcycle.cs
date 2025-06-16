using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; } // Cylinder volume in cubic centimeters (cc)
        public Motorcycle(string regNr, string color, int numberOfWheels, int cylinderVolume) : base(regNr, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Cylinder Volume: {CylinderVolume}cc";
        }
    }
}
