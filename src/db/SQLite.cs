using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projeto_Teste.src.db
{
    class SQLite
    {
        private string _path;

        public SQLite()
        {
            string startUpPath = AppDomain.CurrentDomain.BaseDirectory;

            _path = "Data Source = ..\\..\\..\\SQLite\\database";
        }

        public Person FindById(int id)
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string sql = "SELECT * FROM person WHERE id = @Id";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

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
    }

}