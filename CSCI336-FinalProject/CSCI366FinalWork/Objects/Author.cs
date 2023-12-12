using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCI336_FinalProject.CSCI366FinalWork.Objects
{
    public class Author
    {
        // Instance variables
        public int Author_id { get; private set; }
        public string first_name { get; private set; }
        public string last_name { get; private set; }

        // Constructor method
        public Author(int author_id, string first_name, string last_name)
        {
            Author_id = author_id;
            this.first_name = first_name;
            this.last_name = last_name;
        }



        // SQL Methods

        // Method for returning list of authors
        public static List<Author> GetAuthorsAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM author", conn);

                // Run command and make list of authors
                List<Author> authors = new List<Author>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Author author = new Author(Convert.ToInt32(reader["Author_id"]),
                        Convert.ToString(reader["first_name"]),
                        Convert.ToString(reader["last_name"]));

                    authors.Add(author);
                }
                // Close db connection
                conn.Close();

                // Return list of authors
                return authors;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for adding an Author
        public static void AddAuthor(string first_name, string last_name)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "INSERT INTO author (first_name, last_name) VALUES(@first_name, @last_name)";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for updating an Author
        public static void UpdateAuthor(string first_name, string last_name, int author_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "UPDATE author SET first_name = @first_name, last_name = @last_name WHERE Author_id = @author_id;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@author_id", author_id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for deleting an Author
        public static void DeleteAuthor(int author_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "DELETE FROM authoredby WHERE author_id = @author_id; DELETE FROM author WHERE author_id = @author_id;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@author_id", author_id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}