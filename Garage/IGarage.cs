using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IGarage<T> where T : class, IVehicle
    {
        ParkingResult ParkVehicle(T vehicle);
        bool RemoveVehicle(string regNr);
        IEnumerable<T> GetAllVehicles();
        int Capacity { get; }
        int Count { get; }
    }
}
