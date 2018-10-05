using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;

    private double workHoursPerDay;

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        private set
        {
            if (value < 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }

            this.weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
            }

            this.workHoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal CalculateSalaryPerHour()
    {
        return this.WeekSalary / (decimal)(this.WorkHoursPerDay * 5);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(base.ToString())
            .AppendLine(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

        return builder.ToString().TrimEnd();
    }
}