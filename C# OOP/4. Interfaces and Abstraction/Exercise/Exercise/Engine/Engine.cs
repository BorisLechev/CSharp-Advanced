using Exercise.Contracts;
using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.Engine
{
    public class Engine
    {
        private readonly List<ISoldier> army;

        public void Run()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string soldierType = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];
                decimal salary = decimal.Parse(tokens[4]);

                if (soldierType == "Private")
                {
                    Private privateSoldier = new Private(id, firstName, lastName, salary);
                    this.army.Add(privateSoldier);
                }

                else if (soldierType == "LieutenantGeneral")
                {
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesToAdd = tokens.Skip(5).ToArray();

                    foreach (string privateId in privatesToAdd)
                    {
                        ISoldier soldierToAdd = this.army.FirstOrDefault(s => s.Id == privateId);

                        lieutenantGeneral.AddSoldier(soldierToAdd);
                    }

                    this.army.Add(lieutenantGeneral);
                }

                else if (soldierType == "Engineer")
                {
                    try
                    {
                        string corps = tokens[5];

                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairTokens = tokens.Skip(6).ToArray();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    this.army.Add()
                }
            }
        }
    }
}
