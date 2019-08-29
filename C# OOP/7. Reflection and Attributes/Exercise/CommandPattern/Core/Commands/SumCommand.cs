using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class SumCommand : ICommand
    {
        public string Execute(string[] args)
        {
            double[] numbers =
                args
                .Select(double.Parse)
                .ToArray();

            return $"Current sum: {numbers.Sum().ToString()}";
        }
    }
}
