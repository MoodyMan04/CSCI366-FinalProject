using Npgsql;

namespace CSCI336_FinalProject.CSCI366FinalWork
{
    public class Database
    {
        private static string connString = "Host=localhost;Database=ACMLibrary;Username=postgres;Password=***********;Persist Security Info=True;Port=5433";
        NpgsqlConnection db = new NpgsqlConnection();
    }
}