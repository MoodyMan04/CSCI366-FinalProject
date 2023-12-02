using Npgsql;
using System;
using System.Collections.Generic;

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

        /// <summary>  
        /// fetches all books
        /// </summary>
        /// <returns> a list of all books </returns>
        public static List<Book> GetBooksAll() // UNTESTED
        {
            // Get db connection
            NpgsqlConnection conn = DatabaseManager.GetConnection();

            // Open connection to db
            conn.Open();

            // Make command for db
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM books ORDER BY title", conn);

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

        /// <summary>
        /// fetches books by passed in ID
        /// </summary>
        /// <param name="id"> id of book</param>
        /// <returns> new Book objects </returns>
        public static Book GetBookById(int Book_id) // UNTESTED
        {
            // Get db connection
            NpgsqlConnection conn = DatabaseManager.GetConnection();

            // Open connection to db
            conn.Open();

            // Make command for db
            string query = "SELECT * FROM books WHERE Book_id = @Book_id";
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

        /// <summary>
        /// fectehs all books by title
        /// </summary>
        /// <param name="title"> title of book </param>
        /// <returns> a list of book objects </returns>
        public static List<Book> GetBookByTitle(string title)
        {
            // Get db connection
            NpgsqlConnection conn = DatabaseManager.GetConnection();

            // Open connection to db
            conn.Open();

            // Make command for db
            string query = "SELECT * FROM books WHERE title = @title";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue($"title={title}");
            cmd.Prepare();

            List<Book> books = new List<Book>();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

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
            conn.Close();

            return books;
        }

        /// <summary>
        /// fecthes books by a language
        /// </summary>
        /// <param name="language"> the language of the book</param>
        /// <returns> a list of book objects </returns>
        public static List<Book> GetBookByLanguage(String language)
        {
            NpgsqlConnection conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT * FROM books WHERE dev_language = @lang";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@language", language);
            cmd.Prepare();

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
            conn.Close();
            return books;
        }

        /// <summary>
        ///  returns all book counts
        /// </summary>
        /// <returns> int </returns>
        public static long GetBookCountAll()
        {
            NpgsqlConnection conn = DatabaseManager.GetConnection();
            conn.Open();

            string query = "SELECT COUNT(*";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            long count = (long)cmd.ExecuteScalar();
            conn.Close();
            return count;

        }
    }
}