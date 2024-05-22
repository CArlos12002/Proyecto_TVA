using Microsoft.AspNetCore.Mvc;
using TVA_CAR.Data;
using TVA_CAR.Models;
using System.Collections.Generic;

namespace TVA_CAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes(string nombre, string clave, string estatus)
        {
            return _clienteRepository.GetClientes(nombre, clave, estatus);
        }
    }
}