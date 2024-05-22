using System.Collections.Generic;
using TVA_CAR.Models;

namespace TVA_CAR.Data
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes(string nombre, string clave, string estatus);
    }
}
