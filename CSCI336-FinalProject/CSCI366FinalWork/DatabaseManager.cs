using Npgsql;

namespace CSCI336_FinalProject.CSCI366FinalWork
{
    public class DatabaseManager
    {
        // Connection string for database (WHEN IN USE, CHANGE PASSWORD TO YOUR LOCAL PASSWORD FOR POSTGRES)
        private static string connString = "Host=localhost;Port=5433;Database=ACMLibrary;Username=postgres;Password=Sub-rem2030;Persist Security Info=True";

        // Pulic method for opening and getting a connection
        public static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            return conn;
        }
    }
}