using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IHandler
    {
        ParkingResult AddVehicle(IVehicle vehicle);
        bool RemoveVehicle(string regNr);
        IEnumerable<IVehicle> GetAllVehicles();
        Dictionary<string, int> GetVehicleTypeCounts();
        IEnumerable<IVehicle> SearchVehicle(string? color = null, int? numberOfWheels = null, string? type = null, string? regNr = null);
    }
}
