using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Manager
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the Garage Management System!");

            // Initialize
            int capacity = GetGarageCapacity();
            var garage = new Garage<IVehicle>(capacity);
            var handler = new Handler(garage);
            var ui = new UI(handler);

            // Start the UI
            ui.Start();
        }

        // Prompts the user for the garage capacity and validates the input
        private int GetGarageCapacity()
        {
            while (true)
            {
                Console.Write("Enter the garage capacity (number of vehicles): ");
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int capacity) && capacity > 0)
                {
                    return capacity;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }
        }
    }
}
