using System.Collections.Generic;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public interface IDetalleVentaRepository
    {
        void AddDetalleVenta(DetalleVenta detalleVenta);
        IEnumerable<DetalleVenta> GetDetallesByVentaId(int ventaId);
    }
}
