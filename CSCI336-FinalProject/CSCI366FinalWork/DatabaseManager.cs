using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCI336_FinalProject.CSCI366FinalWork
{
    public class DatabaseManager
    {
        // Connection string for database (HOPEFULLY THIS WORKS, PASSWORD MAY BE AN ISSUE)
        private static string connString = "Host=localhost;Port=5433;Database=ACMLibrary;Username=postgres;Password=***;Persist Security Info=True";

        // Pulic method for opening and getting a connection
        public static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            return conn; 
        }
    }
}