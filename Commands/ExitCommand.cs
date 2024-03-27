using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

public class ExitCommand : ICommand
{
    public string Name => "exit";

    public void Execute(string[] args)
    {
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }
}