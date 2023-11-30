using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace CSCI336_FinalProject.CSCI366FinalWork.Objects
{
    public class Book
    {
        // Private instance variables
        public int Book_id { get; private set; }
        public string title { get; private set; }
        public string publisher { get; private set; }
        public string dev_language { get; private set; }
        public DateTime date_published { get; private set; }

        // SQL methods

        // Static method to get a list of all books (called by webpage)
        // (Example of sql method, returning a list of book objects)
        public static List<Book> GetBooksAll()
        {
            // Get db connection
            NpgsqlConnection conn = DatabaseManager.GetConnection();

            // Make command for db
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Book ORDER BY Title", conn);

            // Open connection to db
            conn.Open();

            // Run command and make list of books
            List<Book> books = new List<Book>();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book();
                book.Book_id = Convert.ToInt32(reader["Book_id"]);
                book.title = Convert.ToString(reader["title"]);
                book.publisher = Convert.ToString(reader["publisher"]);
                book.dev_language = Convert.ToString(reader["dev_language"]);
                book.date_published = Convert.ToDateTime(reader["date_published"]);

                books.Add(book);
            }

            // close db connection
            conn.Close();

            // return list of books
            return books;
        }
    }
}