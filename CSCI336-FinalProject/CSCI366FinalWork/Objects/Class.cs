using Npgsql;
using System;
using System.Collections.Generic;

namespace CSCI336_FinalProject.CSCI366FinalWork.Objects
{
    public class Class
    {
        // Instance variables
        public int Class_id { get; private set; }
        public string class_name { get; private set; }
        public string class_description { get; private set; }

        // Constructor method
        public Class(int class_id,  string class_name, string class_description)
        {
            Class_id = class_id;
            this.class_name = class_name;
            this.class_description = class_description;
        }

        // SQL Methods

        // Method for returning list of authors
        public static List<Class> GetClassAll()
        {
            try
            {
                // Get db connection
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                // Open connection to db
                conn.Open();

                // Make command for db
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM classes", conn);

                // Run command and make list of classes
                List<Class> classes = new List<Class>();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class class1 = new Class(
                        Convert.ToInt32(reader["Class_id"]),
                        Convert.ToString(reader["class_name"]),
                        Convert.ToString(reader["class_description"]));

                    classes.Add(class1);
                }
                // Close db connection
                conn.Close();

                // Return list of classes
                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// fetches Class by passes in Id.
        /// </summary>
        /// <param name="id"> the id of the specified book </param>
        /// <returns> a list of class objects </returns>
        /// <exception cref="Exception"> if there is a issue with fetching class</exception>
        public static List<Class> getClassByID(int id)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();

                conn.Open();
                string query = "SELECT class_name FROM classes WHERE class_id = @ClassId";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClassId", id);
                cmd.Prepare();

                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Class> classes = new List<Class>();

                while (reader.Read())
                {
                    Class csciclass = new Class();
                    csciclass.Class_id = Convert.ToInt32(reader["Class_id"]);
                    csciclass.class_name = Convert.ToString(reader["class_name"]);
                    csciclass.class_description = Convert.ToString(reader["class_description"]);

                    classes.Add(csciclass);
                }
                conn.Close();

                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Adds a class with the given class name and description parameters.
        /// </summary>
        /// <param name="className"> the name of the new class </param>
        /// <param name="classDescription"> the description of the new class </param>
        /// <exception cref="Exception"> if there was an issue inserting new class </exception>
        public static void AddClass(string className, string classDescription)
        {
            try
            {
                NpgsqlConnection conn = DatabaseManager.GetConnection();
                conn.Open();

                string query = "INSERT INTO classes (class_name, class_description) VALUES (@className, @classDescription)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@className", className);
                cmd.Parameters.AddWithValue("@classDescription", classDescription);
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