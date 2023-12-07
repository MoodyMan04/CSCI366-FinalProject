using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}