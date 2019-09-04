using MortalEngines.Core;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachinesManager machinesManager = new MachinesManager();

            machinesManager.HirePilot("Pesho");
            machinesManager.ManufactureFighter("F1", 100, 200);
            machinesManager.ManufactureTank("T1", 300, 400);

            machinesManager.EngageMachine("Pesho", "F1");
            machinesManager.EngageMachine("Pesho", "T1");

            System.Console.WriteLine(machinesManager.PilotReport("Pesho"));
        }
    }
}