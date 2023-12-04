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
        public static List<Book> GetBooksAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM books", conn);

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        /// <summary>
        /// fetches books by passed in ID
        /// </summary>
        /// <param name="id"> id of book</param>
        /// <returns> new Book objects </returns>
        public static List<Book> GetBookById(int Book_id)
        {
            try
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

                List<Book> books = new List<Book>();

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

                // Close connection to db
                conn.Close();

                // Return book
                return books;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        /// <summary>
        /// fetches all books by title
        /// </summary>
        /// <param name="title"> title of book </param>
        /// <returns> a list of book objects </returns>
        public static List<Book> GetBookByTitle(string title)
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                string query = "SELECT * FROM books WHERE title ILIKE @title";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", '%' + title + '%');
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        /// <summary>
        /// fecthes books by a language
        /// </summary>
        /// <param name="language"> the language of the book</param>
        /// <returns> a list of book objects </returns>
        public static List<Book> GetBookByLanguage(String language)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "SELECT * FROM books WHERE dev_language ILIKE @lang";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@lang", '%' + language + '%');
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        /// <summary>
        ///  returns all book counts
        /// </summary>
        /// <returns> int </returns>
        public static long GetBookCountAll()
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "SELECT COUNT(*) FROM books";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                long count = (long)cmd.ExecuteScalar();
                conn.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        /// <summary>
        /// insert a book and clss id into linking table with if the book is required or not.
        /// </summary>
        /// <param name="bookid"> id of book </param>
        /// <param name="classid"> id of class </param>
        /// <param name="req"> a boolean to specify if the book is required </param>
        public static void AddClassRequirement(int bookid, int classid, Boolean req)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "INSERT INTO asscoiatedwith (class_id, book_id, is_required) VALUES(@bookid, @classid, @req)";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookid", bookid);
                cmd.Parameters.AddWithValue("@classid", classid);
                cmd.Parameters.AddWithValue("@req", req);
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