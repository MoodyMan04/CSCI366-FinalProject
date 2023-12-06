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
                    Author author = new Author();
                    author.Author_id = Convert.ToInt32(reader["Author_id"]);
                    author.first_name = Convert.ToString(reader["first_name"]);
                    author.last_name = Convert.ToString(reader["last_name"]);

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
    }
}