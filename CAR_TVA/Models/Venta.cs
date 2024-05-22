namespace TVA_CAR.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string Estatus { get; set; }
    }
}