using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get; }
        int NumberOfWheels { get; }
    }
}
