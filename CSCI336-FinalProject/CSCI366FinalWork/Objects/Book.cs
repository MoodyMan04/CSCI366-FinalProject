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

        // Constructor method
        public Book(int book_id, string title, string publisher, string dev_language, DateTime date_published)
        {
            Book_id = book_id;
            this.title = title;
            this.publisher = publisher;
            this.dev_language = dev_language;
            this.date_published = date_published;
        }

        // Static variable for return date (NOT IN DB)
        public static DateTime return_date { get; set; } = new DateTime(2023, 12, 15, 17, 00, 00);

        // Struct for checked out table
        public struct CheckedOut
        {
            public int user_id { get; set; }
            public int book_id { get; set; }
            public bool is_checkedout { get; set; }
            public DateTime checked_out_time { get; set; }
        }

        // Struct for associated with table
        public struct AssociatedWith
        {
            public int class_id { get; set; }
            public int book_id { get; set; }
            public bool is_required { get; set; }
        }

        // Struct for authored by table
        public struct AuthoredBy
        {
            public int author_id { get; set; }
            public int book_id { get; set; }
        }

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
                    Book book = new Book(Convert.ToInt32(reader["Book_id"]),
                        Convert.ToString(reader["title"]),
                        Convert.ToString(reader["publisher"]),
                        Convert.ToString(reader["dev_language"]),
                        Convert.ToDateTime(reader["date_published"]));

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

        // Method for returning list of everything in the checked out table
        public static List<CheckedOut> GetCheckedOutAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM checkedout", conn);

                // Run command and make list of all checked out books and their values
                List<CheckedOut> checkedOutBooks = new List<CheckedOut>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CheckedOut checkedOutBook = new CheckedOut();
                    checkedOutBook.user_id = Convert.ToInt32(reader["User_id"]);
                    checkedOutBook.book_id = Convert.ToInt32(reader["Book_id"]);
                    checkedOutBook.is_checkedout = Convert.ToBoolean(reader["is_checkedout"]);
                    checkedOutBook.checked_out_time = Convert.ToDateTime(reader["checked_out_time"]);

                    checkedOutBooks.Add(checkedOutBook);
                }

                // Close db connection
                conn.Close();

                // Return list of books
                return checkedOutBooks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for returning list of all currently checked out books and their values
        public static List<CheckedOut> GetCurrentlyCheckedOutAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM checkedout WHERE is_checkedout = true", conn);

                // Run command and make list of all checked out books and their values
                List<CheckedOut> checkedOutBooks = new List<CheckedOut>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CheckedOut checkedOutBook = new CheckedOut();
                    checkedOutBook.user_id = Convert.ToInt32(reader["User_id"]);
                    checkedOutBook.book_id = Convert.ToInt32(reader["Book_id"]);
                    checkedOutBook.is_checkedout = Convert.ToBoolean(reader["is_checkedout"]);
                    checkedOutBook.checked_out_time = Convert.ToDateTime(reader["checked_out_time"]);

                    checkedOutBooks.Add(checkedOutBook);
                }

                // Close db connection
                conn.Close();

                // Return list of books
                return checkedOutBooks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for returning list of currently checked out books for the current user
        public static List<(Book, DateTime)> GetCurrentCheckedOutForUser(int id)
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT b.Book_id, b.title, b.publisher, b.dev_language, b.date_published, ch.checked_out_time " +
                      "FROM books as b " +
                      "JOIN checkedout as ch on b.Book_id = ch.Book_id " +
                      "WHERE ch.is_checkedout = true AND ch.User_id = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.Prepare();

                // Run command and make list of all checked out books and their values as a Book object
                List<(Book, DateTime)> checkedOutBooks = new List<(Book, DateTime)>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book checkedOutBook = new Book(Convert.ToInt32(reader["Book_id"]),
                        Convert.ToString(reader["title"]),
                        Convert.ToString(reader["publisher"]),
                        Convert.ToString(reader["dev_language"]),
                        Convert.ToDateTime(reader["date_published"]));
                    DateTime checkeOutTime = Convert.ToDateTime(reader["checked_out_time"]);

                    checkedOutBooks.Add((checkedOutBook, checkeOutTime));
                }

                // Close db connection
                conn.Close();

                // Return list of books
                return checkedOutBooks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for returning list of everything in the associated with table
        public static List<AssociatedWith> GetAssociatedWithAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM asscoiatedwith", conn);

                // Run command and make list of all associated with connections and their values
                List<AssociatedWith> associatedWithLinks = new List<AssociatedWith>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AssociatedWith associatedWithLink = new AssociatedWith();
                    associatedWithLink.class_id = Convert.ToInt32(reader["Class_id"]);
                    associatedWithLink.book_id = Convert.ToInt32(reader["Book_id"]);
                    associatedWithLink.is_required = Convert.ToBoolean(reader["is_required"]);

                    associatedWithLinks.Add(associatedWithLink);
                }

                // Close db connection
                conn.Close();

                // Return list of associated with connections
                return associatedWithLinks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for returning list of everything from the authored by table
        public static List<AuthoredBy> GetAuthoredByAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM authoredby", conn);

                // Run command and make list of all authored by connections and their values
                List<AuthoredBy> authoredByLinks = new List<AuthoredBy>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AuthoredBy authoredByLink = new AuthoredBy();
                    authoredByLink.author_id = Convert.ToInt32(reader["Author_id"]);
                    authoredByLink.book_id = Convert.ToInt32(reader["Book_id"]);

                    authoredByLinks.Add(authoredByLink);
                }

                // Close db connection
                conn.Close();

                // Return list of authored by connections
                return authoredByLinks;
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
                    Book book = new Book(Convert.ToInt32(reader["Book_id"]),
                        Convert.ToString(reader["title"]),
                        Convert.ToString(reader["publisher"]),
                        Convert.ToString(reader["dev_language"]),
                        Convert.ToDateTime(reader["date_published"]));

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
                    Book book = new Book(Convert.ToInt32(reader["Book_id"]),
                        Convert.ToString(reader["title"]),
                        Convert.ToString(reader["publisher"]),
                        Convert.ToString(reader["dev_language"]),
                        Convert.ToDateTime(reader["date_published"]));

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
                    Book book = new Book(Convert.ToInt32(reader["Book_id"]),
                         Convert.ToString(reader["title"]),
                         Convert.ToString(reader["publisher"]),
                         Convert.ToString(reader["dev_language"]),
                         Convert.ToDateTime(reader["date_published"]));

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

        // Method for returning list of books that are made by passed author last name
        public static List<Book> GetBookByAuthor(string author_lastname)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "SELECT books.book_id, books.title, books.publisher, books.dev_language, books.date_published " +
                    "FROM authoredby " +
                    "JOIN books on authoredby.book_id = books.book_id " +
                    "JOIN author on authoredby.author_id = author.author_id " +
                    "WHERE author.last_name ILIKE @author_lastname";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@author_lastname", '%' + author_lastname + '%');
                cmd.Prepare();

                List<Book> books = new List<Book>();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Book book = new Book(Convert.ToInt32(reader["Book_id"]),
                         Convert.ToString(reader["title"]),
                         Convert.ToString(reader["publisher"]),
                         Convert.ToString(reader["dev_language"]),
                         Convert.ToDateTime(reader["date_published"]));

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

        // Method for returning list of books that are used by a class
        public static List<Book> GetBookByClass(string className)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "SELECT books.book_id, books.title, books.publisher, books.dev_language, books.date_published " +
                    "FROM books " +
                    "JOIN asscoiatedwith ON books.book_id = asscoiatedwith.book_id " +
                    "JOIN classes ON asscoiatedwith.class_id = classes.class_id " +
                    "WHERE class_name ILIKE @className";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@className", '%' + className + '%');
                cmd.Prepare();

                List<Book> books = new List<Book>();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Book book = new Book(Convert.ToInt32(reader["Book_id"]),
                         Convert.ToString(reader["title"]),
                         Convert.ToString(reader["publisher"]),
                         Convert.ToString(reader["dev_language"]),
                         Convert.ToDateTime(reader["date_published"]));

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

        // Method to check out a book
        public static void CheckOutBook(int user_id, int book_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "INSERT INTO checkedout (user_id, book_id, is_checkedout, checked_out_time) " +
                    "SELECT @userID, @bookID, @is_checkedout, @checked_out_time " +
                    "WHERE NOT EXISTS (SELECT book_id, is_checkedout " +
                    "FROM checkedout WHERE book_id = @bookID AND is_checkedout = true)";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", user_id);
                cmd.Parameters.AddWithValue("@bookID", book_id);
                cmd.Parameters.AddWithValue("@is_checkedout", true);
                cmd.Parameters.AddWithValue("@checked_out_time", DateTime.Now);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for returning a book
        public static void ReturnBook(int user_id, int book_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "UPDATE checkedout SET is_checkedout = false " +
                    "WHERE user_id = @user_id AND book_id = @book_id;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@book_id", book_id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Method for adding book
        public static void AddBook(string title, string publisher, string dev_language, DateTime date_published)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "INSERT INTO books " +
                    "(title, publisher, dev_language, date_published) " +
                    "VALUES(@title, @publisher, @dev_language, @date_published)";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                cmd.Parameters.AddWithValue("@dev_language", dev_language);
                cmd.Parameters.AddWithValue("@date_published", date_published);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //Method for updating book
        public static void UpdateBook(string title, string publisher, string dev_language, DateTime date_published, int book_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "UPDATE books SET title = @title, publisher = @publisher, dev_language = @dev_language, date_published = @date_published WHERE book_id = @book_id;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                cmd.Parameters.AddWithValue("@dev_language", dev_language);
                cmd.Parameters.AddWithValue("@date_published", date_published);
                cmd.Parameters.AddWithValue("@book_id", book_id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //Method for deleting book
        public static void DeleteBook(int book_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "DELETE FROM asscoiatedwith WHERE book_id = @book_id; DELETE FROM authoredby WHERE book_id = @book_id; DELETE FROM checkedout WHERE book_id = @book_id; DELETE FROM books WHERE book_id = @book_id;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@book_id", book_id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void AddAuthoredBy(int author_id, int book_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "INSERT INTO authoredby (author_id, book_id) VALUES (@author_id, @book_id)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@book_id", book_id);
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

        // Method for deleting an AuthoredBy
        public static void DeleteAuthoredBy(int author_id, int book_id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "DELETE FROM authoredby WHERE author_id = @author_id AND book_id = @book_id;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@author_id", author_id);
                cmd.Parameters.AddWithValue("@book_id", book_id);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
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
        public static void AddAssociatedWith(int bookid, int classid, bool req)
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