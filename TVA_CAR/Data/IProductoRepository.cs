using System.Collections.Generic;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetProductos();
    }
}
