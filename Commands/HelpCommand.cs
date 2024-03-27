using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HelpCommand : ICommand
{
    public string Name => "help";
    private readonly List<ICommand> commands;

    public HelpCommand(List<ICommand> commands)
    {
        this.commands = commands;
    }

    public void Execute(string[] args)
    {
        Console.WriteLine("Available commands:");
        foreach (var command in commands)
        {
            Console.WriteLine($"- {command.Name}");
        }
        Console.WriteLine("Type 'command_name' to execute a command. Use 'exit' to quit the application.");
    }
}
