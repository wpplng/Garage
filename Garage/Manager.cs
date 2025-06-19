using Garage.ConsoleUI;
using Garage.GarageLogic;
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

            // Populate the garage with mock vehicles if the user chooses to
            if (AskYesNo("Do you want to populate the garage with mock vehicles (y/n): "))
            {
                PopulateGarageWithMockVehicles(handler);
            }

            var ui = new UI(handler);

            // Start the UI
            ui.Start();
        }

        // Populates the garage with mock vehicles for demonstration purposes
        private void PopulateGarageWithMockVehicles(IHandler handler)
        {
            handler.AddVehicle(new Car("ABC123", "Red", 4, FuelType.Gasoline));
            handler.AddVehicle(new Motorcycle("XYZ987", "Black", 2, 600));
            handler.AddVehicle(new Boat("BOAT01", "Blue", 0, 7));
            handler.AddVehicle(new Bus("BUS99", "Yellow", 6, 45));
            handler.AddVehicle(new Airplane("PLANE1", "White", 10, 2));
        }

        // Asks the user a yes/no question and returns true for 'Y' and false for 'N'
        private bool AskYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y) return true;
                if (key == ConsoleKey.N) return false;
                Console.WriteLine("Press Y or N.");
            }
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
