using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandParser
{
    private readonly List<ICommand> commands;

    public CommandParser()
    {
        commands = new List<ICommand>
            {
                new ShowCommand(),
                new SetCommand(),
                new ExitCommand(),
                new ConversionConsole.Commands.UseCommand()
                // Add other commands here
            };

        // Add HelpCommand after all other commands have been added
        commands.Add(new HelpCommand(commands));
    }

    public void ExecuteCommand(string input)
    {
        var parts = input.Split(' ', 2);
        var commandName = parts[0];
        var args = parts.Length > 1 ? parts[1].Split(' ') : new string[0];

        var command = commands.Find(c => c.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));
        if (command != null)
        {
            command.Execute(args);
        }
        else
        {
            Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
        }
    }
}

