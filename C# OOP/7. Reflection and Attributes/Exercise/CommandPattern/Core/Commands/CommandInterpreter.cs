using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_SUFFIX = "Command";

        public string Read(string inputLine)
        {
            string[] tokens =
                inputLine
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = tokens[0] + COMMAND_SUFFIX;
            string[] commandArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            //if (typeToCreate == null)
            //{
            //    throw new InvalidOperationException("Invalid Command Type.");
            //}

            Object instance = Activator.CreateInstance(typeToCreate);
            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
