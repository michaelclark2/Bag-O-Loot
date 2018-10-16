using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace BagOLoot
{
    public class DatabaseInterface
    {

        private string _connectionString;

        public DatabaseInterface(string database)
        {
            _connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build().GetConnectionString(database);
        }

        public void Query(string command, Action<SqlDataReader> handler)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dbCommand = connection.CreateCommand();
                dbCommand.CommandText = command;

                using (SqlDataReader reader = dbCommand.ExecuteReader())
                {
                    handler(reader);
                }
                dbCommand.Dispose();
            }
        }

        public int Insert(string command)
        {
            int insertedId = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dbCommand = connection.CreateCommand();
                dbCommand.CommandText = command;
                

                this.Query(command + " SELECT SCOPE_IDENTITY()",
                    (SqlDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            insertedId = (int)reader.GetDecimal(0);
                        }
                    });
                dbCommand.Dispose();

            }

            return insertedId;
        }

        public void Delete(string command)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dbCommand = connection.CreateCommand();
                dbCommand.CommandText = command;

                dbCommand.ExecuteNonQuery();

                dbCommand.Dispose();
            }
        }
    }
}
