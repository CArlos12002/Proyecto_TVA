using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;
        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Cliente> GetClientes(string nombre, string clave, string estatus)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM CLIENTE WHERE NOMBRE LIKE :nombre AND CLAVE LIKE :clave AND ESTATUS = :estatus";
                return connection.Query<Cliente>(query, new { nombre = $"%{nombre}%", clave = $"%{clave}%", estatus }).ToList();
            }
        }
    }
}