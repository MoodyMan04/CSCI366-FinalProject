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
        // Instance variables
        public int Book_id { get; private set; }
        public string title { get; private set; }
        public string publisher { get; private set; }
        public string dev_language { get; private set; }
        public DateTime date_published { get; private set; }

        // SQL methods

        // Static method to get a list of all books (called by webpage)
        // (Example of sql method, returning a list of book objects)
        public static List<Book> GetBooksAll() // UNTESTED
        {
            // Get db connection
            NpgsqlConnection conn = DatabaseManager.GetConnection();

            // Open connection to db
            conn.Open();

            // Make command for db
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Books ORDER BY title", conn);

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

            // Close db connection
            conn.Close();

            // Return list of books
            return books;
        }

        // Static method to get book with matching id (called by webpage)
        // (Example of prepared sql command, returning a book)
        public static Book GetBookById(int Book_id) // UNTESTED
        {
            // Get db connection
            NpgsqlConnection conn = DatabaseManager.GetConnection();

            // Open connection to db
            conn.Open();

            // Make command for db
            string query = "SELECT * FROM Books WHERE Book_id = @Book_id";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Book_id", Book_id);
            cmd.Prepare();

            // Get data out of command and get book object
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Book book = new Book();
            book.Book_id = Convert.ToInt32(reader["Book_id"]);
            book.title = Convert.ToString(reader["title"]);
            book.publisher = Convert.ToString(reader["publisher"]);
            book.dev_language = Convert.ToString(reader["dev_language"]);
            book.date_published = Convert.ToDateTime(reader["date_published"]);

            // Close connection to db
            conn.Close();

            // Return book
            return book;
        } 

        // REST OF SQL METHODS FOR BOOK CLASS ADDED HERE
    }
}