using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCommand : ICommand
{
    public string Name => "show";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: show [modules|config]");
            return;
        }

        switch (args[0].ToLower())
        {
            case "modules":
                Console.WriteLine("Available modules: Extract, Transform, Load, Validate");
                break;
            case "config":
                Console.WriteLine("Current settings:");
                Console.WriteLine($"- connectionstring: {AppConfigManager.GetSetting("connectionstring")}");
                Console.WriteLine($"- linkedServer: {AppConfigManager.GetSetting("linkedserver")}");
                break;
            default:
                Console.WriteLine("Unknown argument for show command.");
                break;
        }
    }
}