using ConversionConsole.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionConsole.Commands
{
    public class UseCommand : ICommand
    {
        public string Name => "use";
        private readonly Dictionary<string, IModule> availableModules;
        private IModule currentModule;

        public UseCommand()
        {
            // Initialize available modules here
            availableModules = new Dictionary<string, IModule>
            {
                { "extract", new Modules.ExtractModule() }
            };
        }

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: use [module]");
                return;
            }

            string moduleName = args[0].ToLower();
            if (availableModules.TryGetValue(moduleName, out currentModule))
            {
                Console.WriteLine($"Using module: {moduleName}");
                currentModule.Initialize();

                // If there are more arguments, set them as options
                if (args.Length > 1)
                {
                    var options = ParseOptions(args.Skip(1).ToArray());
                    currentModule.SetOptions(options);
                }

                // You might want to add additional interaction here,
                // such as a sub-prompt for setting options or executing the module.

                // For now, let's just execute the module
                currentModule.Execute();
            }
            else
            {
                Console.WriteLine($"Module '{moduleName}' not found.");
            }
        }

        private Dictionary<string, object> ParseOptions(string[] args)
        {
            var options = new Dictionary<string, object>();
            foreach (string arg in args)
            {
                string[] splitArg = arg.Split('=');
                if (splitArg.Length == 2)
                {
                    options.Add(splitArg[0], splitArg[1]);
                }
                else
                {
                    Console.WriteLine($"Invalid option format: {arg}");
                }
            }
            return options;
        }
    }
}
