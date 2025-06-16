using Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage<T> : IGarage<T>, IEnumerable<T> where T : IVehicle
    {
        private T[] _vehicles;
        private int _capacity;
        private int _count;

        // Constructor to initialize the garage with a specific capacity
        public Garage(int capacity)
        {
            _capacity = capacity;
            _vehicles = new T[_capacity];
            _count = 0;
        }

        public int Capacity => _capacity;
        public int Count => _count;

        // ParkVehicle method to add a vehicle to the garage
        public bool ParkVehicle(T vehicle)
        {
            // Check if the garage is full, the vehicle is null, or if a vehicle with the same registration number already exists
            if (_count >= _capacity || vehicle == null || _vehicles.Any(v => v?.RegistrationNumber == vehicle.RegistrationNumber))
            {
                return false; // Garage is full or vehicle already exists
            }

            // Check for an empty slot in the garage
            for (int i = 0; i < _capacity; i++)
            {
                if (_vehicles[i] == null)
                {
                    _vehicles[i] = vehicle;
                    _count++;
                    return true;
                }
            }
            return false; // Garage is full
        }

        public bool RemoveVehicle(string regNr)
        {
            throw new NotImplementedException();
        }

        public T FindVehicle(string regNr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
