using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class UI : IUI
    {
        private readonly IHandler _handler;

        // Constructor that initializes the UI with a handler instance
        public UI(IHandler handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler), "Handler cannot be null");
        }

        public void Start()
        {
            // Menu with choices for the user
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===GARAGE===");
                Console.WriteLine("1. List of all vehicles in the garage");
                Console.WriteLine("2. Add vehicle");
                Console.WriteLine("3. Remove vehicle");
                Console.WriteLine("4. Search vehicle");
                Console.WriteLine("5. Show number of vehicles per type");
                Console.WriteLine("0. Terminate");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ShowVehicles(_handler.GetAllVehicles());
                        break;
                    case "2":
                        AddVehicleMenu();
                        break;
                    case "3":
                        string regToRemove = GetInput("Enter registration number to remove:");
                        bool removed = _handler.RemoveVehicle(regToRemove);
                        ShowMessage(removed ? "Vehicle removed!" : "Vehicle could not be found.");
                        break;
                    case "4":
                        SearchVehicleMenu();
                        break;
                    case "5":
                        foreach (var pair in _handler.GetVehicleTypeCounts())
                            Console.WriteLine($"{pair.Key}: {pair.Value}");
                        break;
                    case "0":
                        ShowMessage("Terminating...");
                        return;
                    default:
                        ShowMessage("Invalid choice, please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true); // Wait for user input before clearing the console again
            }
        }

        private void SearchVehicleMenu()
        {
            throw new NotImplementedException();
        }

        private void AddVehicleMenu()
        {
            throw new NotImplementedException();
        }

        // Show prompt and read input from the user
        public string GetInput(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine() ?? string.Empty;
        }

        // Show a message to the user
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Display a list of vehicles to the user
        public void ShowVehicles(IEnumerable<IVehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

            if (!vehicles.Any())
            {
                Console.WriteLine("No vehicles found.");
            }
        }
    }
}
