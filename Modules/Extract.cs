using System;
using System.Collections.Generic;

namespace ConversionConsole.Modules
{
    public interface IModule
    {
        string Name { get; }
        void Initialize();
        void SetOptions(Dictionary<string, object> options);
        bool ValidateOptions();
        void Execute();
    }

    public class ExtractModule : IModule
    {
        public string Name => "extract";

        private Dictionary<string, object> options;

        public void Initialize()
        {
            options = new Dictionary<string, object>
            {
                
                {"TestConfigurations", "SELECT * FROM dbo.Table"}, // Input Your Logic for Your Extract part of the ETL process here and continue the same for Transform,Load, and validate.
                {"ExtractSourceData", false}
            };
        }

        public void SetOptions(Dictionary<string, object> newOptions)
        {
            foreach (var option in newOptions)
            {
                if (options.ContainsKey(option.Key))
                {
                    options[option.Key] = option.Value;
                }
                else
                {
                    Console.WriteLine($"Warning: Option '{option.Key}' is not recognized by the {Name} module and was ignored.");
                }
            }
        }

        public bool ValidateOptions()
        {
            // Removed checks for SourcePath and DestinationPath

            // Validate that TestConfigurations is a string
            if (!(options["TestConfigurations"] is string))
            {
                Console.WriteLine("TestConfigurations option must be a SQL query string.");
                return false;
            }

            // Validate that ExtractSourceData is indeed a boolean
            if (!(options["ExtractSourceData"] is bool))
            {
                Console.WriteLine("ExtractSourceData option must be boolean (true or false).");
                return false;
            }

            return true;
        }

        public void Execute()
        {
            if (!ValidateOptions())
            {
                Console.WriteLine("Options validation failed.");
                return;
            }

            string testConfigurationsQuery = (string)options["TestConfigurations"];
            bool extractSourceData = (bool)options["ExtractSourceData"];

            if (!string.IsNullOrWhiteSpace(testConfigurationsQuery))
            {
                Console.WriteLine($"Testing configurations with query: {testConfigurationsQuery}");
                // Execute SQL query logic here
            }

            if (extractSourceData)
            {
                // Since SourcePath and DestinationPath are removed, adjust logic accordingly
                Console.WriteLine("Extracting source data.");
                // Extraction logic here
            }
        }
    }
}
