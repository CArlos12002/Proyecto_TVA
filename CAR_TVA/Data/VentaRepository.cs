using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public class VentaRepository : IVentaRepository
    {
        private readonly string _connectionString;
        public VentaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddVenta(Venta venta)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO VENTA (VENTA_ID, FECHA, CLIENTE_ID, ESTATUS) VALUES (:VentaId, :Fecha, :ClienteId, :Estatus)",
                                   new { venta.VentaId, venta.Fecha, venta.ClienteId, venta.Estatus });
            }
        }

        public IEnumerable<Venta> GetVentas()
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Venta>("SELECT * FROM VENTA").ToList();
            }
        }

        public Venta GetVentaById(int id)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                return connection.QuerySingleOrDefault<Venta>("SELECT * FROM VENTA WHERE VENTA_ID = :id", new { id });
            }
        }
    }
}
