using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly string _connectionString;
        public DetalleVentaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddDetalleVenta(DetalleVenta detalleVenta)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO DETALLE_VENTA (VENTA_ID, PRODUCTO_ID, CANTIDAD, DESCUENTO, TOTAL) VALUES (:VentaId, :ProductoId, :Cantidad, :Descuento, :Total)",
                                   new { detalleVenta.VentaId, detalleVenta.ProductoId, detalleVenta.Cantidad, detalleVenta.Descuento, detalleVenta.Total });
            }
        }

        public IEnumerable<DetalleVenta> GetDetallesByVentaId(int ventaId)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<DetalleVenta>("SELECT * FROM DETALLE_VENTA WHERE VENTA_ID = :ventaId", new { ventaId }).ToList();
            }
        }
    }
}
