namespace TVA_CAR.Models
{
    public class DetalleVenta
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}