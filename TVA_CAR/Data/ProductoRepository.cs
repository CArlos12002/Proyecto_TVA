using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;
        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Producto> GetProductos()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Producto>("SELECT * FROM PRODUCTO WHERE ESTATUS = 'ACTIVO'").ToList();
            }
        }
    }
}
