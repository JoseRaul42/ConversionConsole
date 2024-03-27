using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
public interface ICommand
{
    void Execute(string[] args);
    string Name { get; }
}

