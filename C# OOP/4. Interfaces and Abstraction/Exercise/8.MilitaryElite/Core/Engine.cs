using _8.MilitaryElite.Contracts;
using _8.MilitaryElite.Exceptions;
using _8.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.MilitaryElite.Core
{
    public class Engine
    {
        private readonly List<ISoldier> army;

        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens =
                    input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string soldierType = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];
                decimal salary = decimal.Parse(tokens[4]);

                if (soldierType == "Private")
                {
                    Private soldier = new Private(id, firstName, lastName, salary);
                    this.army.Add(soldier);
                }

                else if (soldierType == "LieutenantGeneral")
                {
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesToAdd = tokens.Skip(5).ToArray();

                    foreach (string privateId in privatesToAdd)
                    {
                        ISoldier soldierToAdd = this.army.FirstOrDefault(s => s.Id == privateId);

                        general.AddPrivate(soldierToAdd);
                    }

                    this.army.Add(general);
                }

                else if (soldierType == "Engineer")
                {
                    try
                    {
                        string corps = tokens[5];

                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairTokens = tokens.Skip(6).ToArray();

                        AddRepairs(engineer, repairTokens);

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsException ex)
                    {
                    }
                }

                else if (soldierType == "Commando")
                {
                    try
                    {
                        string corps = tokens[5];

                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missionsTokens = tokens.Skip(6).ToArray();

                        for (int i = 0; i < missionsTokens.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missionsTokens[i];
                                string state = missionsTokens[i + 1];

                                IMission mission = new Mission(codeName, state);

                                commando.AddMission(mission);
                            }
                            catch (InvalidStateException ex)
                            {
                                continue;
                            }
                        }

                        this.army.Add(commando);
                    }
                    catch (InvalidCorpsException ex)
                    {
                        continue;
                    }
                }

                else if (soldierType == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    this.army.Add(spy);
                }
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (ISoldier soldier in this.army)
            {
                Type type = soldier.GetType();

                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());
            }
        }

        private static void AddRepairs(IEngineer engineer, string[] repairTokens)
        {
            for (int i = 0; i < repairTokens.Length; i += 2)
            {
                string partName = repairTokens[i];
                int hours = int.Parse(repairTokens[i + 1]);

                IRepair repair = new Repair(partName, hours);

                engineer.AddRepair(repair);
            }
        }
    }
}
