using Npgsql;
using System;
using System.Collections.Generic;

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

        // Constructor method
        public Users(int user_id, string first_name, string last_name, bool is_admin, string email, string username, string password)
        {
            User_id = user_id;
            this.first_name = first_name;
            this.last_name = last_name;
            is_Admin = is_Admin;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        // Constructor method for log in
        public Users(bool is_admin, string password)
        {
            is_Admin = is_admin;
            this.password = password;
        }

        // SQL Methods
        // REST OF SQL METHODS FOR USER CLASS ADDED HERE

        // Method to validate login for user
        public static int Login(string username, string password)
        {
            try
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

                Users user = new Users(Convert.ToBoolean(reader["is_Admin"]), Convert.ToString(reader["password"]));

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
            catch
            {
                return 0;
            }
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
                    // Admin should NOT know everyone's passwords
                    Users user = new Users(Convert.ToInt32(reader["User_id"]),
                        Convert.ToString(reader["first_name"]),
                        Convert.ToString(reader["last_name"]),
                        Convert.ToBoolean(reader["is_Admin"]),
                        Convert.ToString(reader["email"]),
                        Convert.ToString(reader["username"]),
                        "****");

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

        /// <summary>
        /// method to fetch the id of the currect.
        /// </summary>
        /// <param name="username"> username of the current user. </param>
        /// <returns></returns>
        /// <exception cref="Exception"> if any SQL exception is thrown </exception>
        public static int GetCurrentUserId(string username)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "SELECT User_id FROM Users WHERE username = @username";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Prepare();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return Convert.ToInt32(reader["User_id"]);
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
                    // Do not allow current user to see own id or password
                    Users user = new Users(0,
                        Convert.ToString(reader["first_name"]),
                        Convert.ToString(reader["last_name"]),
                        Convert.ToBoolean(reader["is_Admin"]),
                        Convert.ToString(reader["email"]),
                        Convert.ToString(reader["username"]),
                        "****");

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