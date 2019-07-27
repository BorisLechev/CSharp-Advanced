using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var database = new Dictionary<int, BankAccount>();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var splittedInput = input.Split(" ");

            string command = splittedInput[0];
            int id = int.Parse(splittedInput[1]);

            switch (command)
            {
                case "Create":
                    Create(database, id);
                    break;
                case "Deposit":
                    Deposit(database, id, splittedInput[2]);
                    break;
                case "Withdraw":
                    Withdraw(database, id, splittedInput[2]);
                    break;
                case "Print":
                    Print(database, id);
                    break;
                default:
                    break;
            }
        }
    }

    private static void Print(Dictionary<int, BankAccount> database, int id)
    {
        if (!database.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }

        else
        {
            Console.WriteLine(database[id]);
        }
    }

    private static void Withdraw(Dictionary<int, BankAccount> database, int id, string moneyAsString)
    {
        if (!database.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }

        else
        {
            if (database[id].Balance >= decimal.Parse(moneyAsString))
            {
                database[id].Balance -= decimal.Parse(moneyAsString);
            }

            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }

    private static void Deposit(Dictionary<int, BankAccount> database, int id, string moneyAsString)
    {
        if (!database.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }

        else
        {
            database[id].Balance += decimal.Parse(moneyAsString);
        }
    }

    private static void Create(Dictionary<int, BankAccount> database, int id)
    {
        if (database.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }

        else
        {
            BankAccount bancAccount = new BankAccount();
            bancAccount.Id = id;
            database.Add(id, bancAccount);
        }
    }
}