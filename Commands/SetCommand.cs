using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

public class SetCommand : ICommand
{
    public string Name => "set";

    public void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: set [ConnectionString|LinkedServer] [value]");
            return;
        }

        string key = args[0];
        string value = args[1];

        // Use AppConfigManager to update App.config settings
        AppConfigManager.SetSetting(key, value);
        Console.WriteLine($"{key} updated successfully.");
    }
}