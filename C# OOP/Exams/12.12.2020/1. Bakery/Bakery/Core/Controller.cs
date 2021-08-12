using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private decimal totalBill = 0.0M;
        private readonly IList<IBakedFood> bakedFoods;
        private readonly IList<IDrink> drinks;
        private readonly IList<ITable> tables;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = type switch
            {
                "Tea" => new Tea(name, portion, brand),
                "Water" => new Water(name, portion, brand),
                _ => null,
            };

            this.drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = type switch
            {
                "Bread" => new Bread(name, price),
                "Cake" => new Cake(name, price),
                _ => null,
            };

            this.bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = type switch
            {
                "InsideTable" => new InsideTable(tableNumber, capacity),
                "OutsideTable" => new OutsideTable(tableNumber, capacity),
                _ => null,
            };

            this.tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables
                .Where(t => t.IsReserved == false)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalBill:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.SingleOrDefault(t => t.TableNumber == tableNumber);

            var sb = new StringBuilder();

            if (table != null)
            {
                var bill = table.GetBill();
                totalBill += bill;

                table.Clear();

                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {bill:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.SingleOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = this.drinks.SingleOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.SingleOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = this.bakedFoods.SingleOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable suitableTable = this.tables
                .FirstOrDefault(t => t.Capacity >= numberOfPeople && t.IsReserved == false);

            if (suitableTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            suitableTable.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, suitableTable.TableNumber, numberOfPeople);
        }
    }
}
