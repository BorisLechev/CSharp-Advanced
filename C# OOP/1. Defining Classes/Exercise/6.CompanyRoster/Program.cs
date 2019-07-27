using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            var employeeData = Console.ReadLine().Split(" ");

            string name = employeeData[0];
            decimal salary = decimal.Parse(employeeData[1]);
            string position = employeeData[2];
            string department = employeeData[3];
            string email = "n/a";
            int age = -1;

            if (employeeData.Length == 5)
            {
                bool isAge = int.TryParse(employeeData[4], out age);

                if (!isAge)
                {
                    email = employeeData[4];
                    age = -1;
                }
            }

            else if (employeeData.Length == 6)
            {
                email = employeeData[4];
                age = int.Parse(employeeData[5]);
            }

            employees.Add(new Employee(name, salary, position, department, email, age));
        }

        var output = employees
            .GroupBy(x => x.Department)
            .Select(x => new
            {
                Department = x.Key,
                AverageSalary = x.Average(em => em.Salary),
                Employees = x.OrderByDescending(y => y.Salary).ToList()
            })
            .OrderByDescending(x => x.AverageSalary)
            .First();

        Console.WriteLine($"Highest Average Salary: {output.Department}");

        foreach (var employee in output.Employees)
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}