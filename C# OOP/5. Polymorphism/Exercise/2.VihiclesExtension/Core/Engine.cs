using _2.VihiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VihiclesExtension.Core
{
    public class Engine
    {
        private static Vehicle car;

        private static Vehicle truck;

        private static Vehicle bus;

        public void Run()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            string[] carInput =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] truckInput =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] busInput =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            car = vehicleFactory.CreateVehicle(carInput);
            truck = vehicleFactory.CreateVehicle(truckInput);
            bus = vehicleFactory.CreateVehicle(busInput);

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
                    try
                    {
                        double liters = double.Parse(commandInput[2]);

                        currentVehicle.RefueledAmountOfFuel(liters);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if (command == "DriveEmpty")
                {
                    Bus currentBus = (Bus)currentVehicle;
                    double distance = double.Parse(commandInput[2]);

                    Console.WriteLine(currentBus.DriveEmpty(distance));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static Vehicle ChooseVehicle(string typeOfVehicle)
        {
            if (typeOfVehicle == "Car")
            {
                return car;
            }

            else if (typeOfVehicle == "Truck")
            {
                return truck;
            }

            else
            {
                return bus;
            }
        }
    }
}
