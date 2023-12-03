using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCI336_FinalProject.CSCI366FinalWork.Objects
{
    public class Users
    {
        // Instance variables
        public int User_id { get; private set; }
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public bool is_Admin { get; private set; }
        public string email { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }

        // SQL Methods
        // REST OF SQL METHODS FOR USER CLASS ADDED HERE

        // Method to validate login for user
        public static int Login(string username, string password)
        {
            // Get connection to db
            NpgsqlConnection conn = DatabaseManager.GetConnection();

            // Open connection
            conn.Open();

            // Create command to get password and is_Admin
            string query = "SELECT password, is_Admin FROM users WHERE username = @username";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Prepare();

            // Get data out of reader
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Users user = new Users();
            user.password = Convert.ToString(reader["password"]);
            user.is_Admin = Convert.ToBoolean(reader["is_Admin"]);

            // Close connection
            conn.Close();

            // Check if user can login
            if (password == user.password)
            {
                if (user.is_Admin)
                    return 2;
                else 
                    return 1; 
            }
            else
                return 0;
        }
    }
}