using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Crud_Cs.src.db
{
    class SQLite
    {
        private string _path;

        public SQLite()
        {
            _path = "Data Source = ..\\..\\..\\SQLite\\database";
        }

        #region Find Querys
        public Person Find(string parameter, string where)
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string sql = "SELECT * FROM person WHERE " + where + " = @value";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@value", parameter);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Person person = new Person();

                            person.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            person.Name = reader.GetString(reader.GetOrdinal("name"));
                            person.LastName = reader.GetString(reader.GetOrdinal("lastname"));
                            person.Document = reader.GetString(reader.GetOrdinal("document"));
                            person.Address = reader.GetString(reader.GetOrdinal("address"));
                            person.Age = reader.GetInt32(reader.GetOrdinal("age"));
                            person.PhoneNumber = reader.GetString(reader.GetOrdinal("phonenumber"));
                            person.BirthDate = reader.GetDateTime(reader.GetOrdinal("birthdate"));

                            return person;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public Person Find(int parameter, string where)
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string sql = "SELECT * FROM person WHERE " + where + " = @value";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@value", parameter);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Person person = new Person();

                            person.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            person.Name = reader.GetString(reader.GetOrdinal("name"));
                            person.LastName = reader.GetString(reader.GetOrdinal("lastname"));
                            person.Document = reader.GetString(reader.GetOrdinal("document"));
                            person.Address = reader.GetString(reader.GetOrdinal("address"));
                            person.Age = reader.GetInt32(reader.GetOrdinal("age"));
                            person.PhoneNumber = reader.GetString(reader.GetOrdinal("phonenumber"));
                            person.BirthDate = reader.GetDateTime(reader.GetOrdinal("birthdate"));

                            return person;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        
        public List<Person> FindMany(string parameter = null, string where = null)
        {
            string sql;

            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                List<Person> list = new List<Person>();

                if(parameter != null) { sql = "SELECT * FROM person WHERE " + where + " = @value"; ; }
                else { sql = "SELECT * FROM person"; }
                
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@value", parameter);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person();

                            person.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            person.Name = reader.GetString(reader.GetOrdinal("name"));
                            person.LastName = reader.GetString(reader.GetOrdinal("lastname"));
                            person.Document = reader.GetString(reader.GetOrdinal("document"));
                            person.Address = reader.GetString(reader.GetOrdinal("address"));
                            person.Age = reader.GetInt32(reader.GetOrdinal("age"));
                            person.PhoneNumber = reader.GetString(reader.GetOrdinal("phonenumber"));
                            person.BirthDate = reader.GetDateTime(reader.GetOrdinal("birthdate"));

                            list.Add(person);
                        }

                        return list = list.Count > 0 ? list : null;
                    }
                }
            }
        }
        #endregion

        public void Insert(Person person)
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string sql = "INSERT INTO person (name, lastname, document, address, age, phonenumber, birthdate) " +
                    "VALUES (@Name, @LastName, @Document, @Address, @Age, @PhoneNumber, @BirthDate)";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Name", person.Name);
                        command.Parameters.AddWithValue("@LastName", person.LastName);
                        command.Parameters.AddWithValue("@Document", person.Document);
                        command.Parameters.AddWithValue("@Address", person.Address);
                        command.Parameters.AddWithValue("@Age", person.Age);
                        command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                        command.Parameters.AddWithValue("@BirthDate", person.BirthDate);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("ERROR: " + err);
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string sql = "DELETE FROM person WHERE id = @Id";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("ERROR: " + err);
                    }
                }
            }
        }

        public void Update(Person person)
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string sql = "UPDATE person " +
                             "SET name = @Name, " +
                                 "lastname = @LastName, " +
                                 "document = @Document, " +
                                 "address = @Address, " +
                                 "age = @Age, " +
                                 "phonenumber = @PhoneNumber, " +
                                 "birthdate = @BirthDate " +
                             "WHERE id = @Id;";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Id", person.Id);
                        command.Parameters.AddWithValue("@Name", person.Name);
                        command.Parameters.AddWithValue("@LastName", person.LastName);
                        command.Parameters.AddWithValue("@Document", person.Document);
                        command.Parameters.AddWithValue("@Address", person.Address);
                        command.Parameters.AddWithValue("@Age", person.Age);
                        command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                        command.Parameters.AddWithValue("@BirthDate", person.BirthDate);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("ERROR: " + err);
                    }
                }
            }
        }
    }
}
