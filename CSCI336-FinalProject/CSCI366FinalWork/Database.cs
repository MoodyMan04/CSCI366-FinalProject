using Npgsql;

namespace CSCI336_FinalProject.CSCI366FinalWork
{
    public class Database
    {
        private static string connString = "Host=localhost;Database=ACMLibrary;Username=postgres;Password=***********;Persist Security Info=True;Port=5433";
        NpgsqlConnection dbConn = new NpgsqlConnection(connString);

        private static NpgsqlDataReader example(string sqlComman)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(connString);
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlComman, dbConn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        private void openConnection(NpgsqlConnection dbConn)
        {
            // below is how you connect
            dbConn.Open();
            // below is how to close
            dbConn.Close();
        }
    }
}