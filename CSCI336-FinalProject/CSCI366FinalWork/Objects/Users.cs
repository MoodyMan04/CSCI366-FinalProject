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

        // Method for returning list of users (ADMIN ONLY)
        public static List<Users> GetUsersAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM users", conn);

                // Run command and make list of users
                List<Users> users = new List<Users>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Users user = new Users();
                    user.User_id = Convert.ToInt32(reader["User_id"]);
                    user.first_name = Convert.ToString(reader["first_name"]);
                    user.last_name = Convert.ToString(reader["last_name"]);
                    user.is_Admin = Convert.ToBoolean(reader["is_Admin"]);
                    user.username = Convert.ToString(reader["username"]);
                    // Admin should NOT know everyone's passwords
                    user.password = "****";

                    users.Add(user);
                }
                // Close db connection
                conn.Close();

                // Return list of users
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static List<Users> GetCurrentUser(string username)
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                string query = "SELECT first_name, last_name, is_Admin, email, username FROM users WHERE username = @username";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Prepare();

                // Get data out of command and get user object
                NpgsqlDataReader reader = cmd.ExecuteReader();

                List<Users> users = new List<Users>();

                while (reader.Read())
                {
                    Users user = new Users();
                    // Do not allow current user to see own id
                    user.User_id = 0;
                    user.first_name = Convert.ToString(reader["first_name"]);
                    user.last_name = Convert.ToString(reader["last_name"]);
                    user.is_Admin = Convert.ToBoolean(reader["is_Admin"]);
                    user.email = Convert.ToString(reader["email"]);
                    user.username = Convert.ToString(reader["username"]);
                    // Do not display current user's password
                    user.password = "****";

                    users.Add(user);
                }

                // Close connection to db
                conn.Close();

                // Return user
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}