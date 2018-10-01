public class Employee
{
    public string Name { get; set; }

    public decimal Salary { get; set; }

    public string Position { get; set; }

    public string Department { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public Employee(string name, decimal salary, string position, string department, string email = "n/a", int age = -1)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = age;
    }
}