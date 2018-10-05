using System;

public class Human
{
    private string firstName;

    private string lastName;

    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(firstName)}");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: {nameof(firstName)}");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(lastName)}");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: {nameof(lastName)}");
            }

            this.lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}{Environment.NewLine}Last Name: {this.LastName}";
    }
}