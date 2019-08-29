using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class CreateFileCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string fileName = args[0];
            string content = "";

            if (args.Length > 1)
            {
                string[] arrayContent = args.Skip(1).ToArray();

                content += string.Join(" ", arrayContent);
            }

            File.WriteAllText(fileName, content);

            return $"File: {fileName} created successfully.";
        }
    }
}
