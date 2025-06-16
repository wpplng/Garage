using Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage<T> : IGarage<T>, IEnumerable<T> where T : class, IVehicle
    {
        private T?[] _vehicles;
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

        // RemoveVehicle method to remove a vehicle by its registration number
        public bool RemoveVehicle(string regNr)
        {
            // Search for the vehicle with the given registration number
            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] != null && _vehicles[i]!.RegistrationNumber.Equals(regNr, StringComparison.OrdinalIgnoreCase))
                {
                    _vehicles[i] = default; // Remove the vehicle
                    _count--;
                    return true; // Vehicle removed successfully
                }
            }
            return false; // Vehicle not found
        }

        // FindVehicle method to find a vehicle by its registration number
        public T? FindVehicle(string regNr)
        {
            // Search for the vehicle with the given registration number and return it if found
            return _vehicles.FirstOrDefault(v => v != null && v.RegistrationNumber.Equals(regNr, StringComparison.OrdinalIgnoreCase));

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
