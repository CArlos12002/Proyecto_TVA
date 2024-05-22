using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace TVA_CAR.Data
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void InitializeDatabase()
        {
            ExecuteSqlScript("DatabaseScripts/Schema.sql");
            ExecuteSqlScript("DatabaseScripts/Data.sql");
        }

        private void ExecuteSqlScript(string scriptPath)
        {
            var script = File.ReadAllText(scriptPath);
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = new OracleCommand(script, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
