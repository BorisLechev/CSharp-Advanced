using EgnHelper;
using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateFromUser(new EgnValidator());
        }

        // vmesto v metoda da ima new EgnValidator() podavam otvan vseki, koito ima metoda IsValid() - dependency inversion
        public static void ValidateFromUser(IEgnValidator validator)
        {
            var egn = Console.ReadLine();

            Console.WriteLine("Valid: " + validator.IsValid(egn));
        }
    }
}
