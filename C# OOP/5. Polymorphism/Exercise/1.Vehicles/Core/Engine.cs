using _1.Vehicles.Models;
using System;

namespace _1.Vehicles.Core
{
    public class Engine
    {
        private static Vehicle car;

        private static Vehicle truck;

        public void Run()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            string[] carInput = 
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] truckInput = 
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            car = vehicleFactory.CreateVehicle(carInput);
            truck = vehicleFactory.CreateVehicle(truckInput);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandInput = 
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandInput[0];
                string typeOfVehicle = commandInput[1];
                Vehicle currentVehicle = ChooseVehicle(typeOfVehicle);

                if (command == "Drive")
                {
                    double distance = double.Parse(commandInput[2]);

                    Console.WriteLine(currentVehicle.Drive(distance));
                }

                else if (command == "Refuel")
                {
                    double liters = double.Parse(commandInput[2]);

                    currentVehicle.RefueledAmountOfFuel(liters);
                }

                else
                {
                    double distance = double.Parse(commandInput[2]);

                    Console.WriteLine(currentVehicle);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private static Vehicle ChooseVehicle(string typeOfVehicle)
        {
            if (typeOfVehicle == "Car")
            {
                return car;
            }

            else
            {
                return truck;
            }
        }
    }
}
