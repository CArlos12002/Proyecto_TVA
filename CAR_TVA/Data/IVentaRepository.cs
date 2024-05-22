using System.Collections.Generic;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public interface IVentaRepository
    {
        void AddVenta(Venta venta);
        IEnumerable<Venta> GetVentas();
        Venta GetVentaById(int id);
    }
}
