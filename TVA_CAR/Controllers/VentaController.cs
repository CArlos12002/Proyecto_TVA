using Microsoft.AspNetCore.Mvc;
using TVA_CAR.Data;
using TVA_CAR.Models;
using System.Collections.Generic;

namespace TVA_CAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IDetalleVentaRepository _detalleVentaRepository;

        public VentaController(IVentaRepository ventaRepository, IDetalleVentaRepository detalleVentaRepository)
        {
            _ventaRepository = ventaRepository;
            _detalleVentaRepository = detalleVentaRepository;
        }

        [HttpPost]
        public IActionResult AddVenta([FromBody] Venta venta)
        {
            _ventaRepository.AddVenta(venta);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Venta> GetVentas()
        {
            return _ventaRepository.GetVentas();
        }

        [HttpGet("{id}")]
        public Venta GetVentaById(int id)
        {
            return _ventaRepository.GetVentaById(id);
        }

        [HttpGet("{id}/detalles")]
        public IEnumerable<DetalleVenta> GetDetallesByVentaId(int id)
        {
            return _detalleVentaRepository.GetDetallesByVentaId(id);
        }
    }
}