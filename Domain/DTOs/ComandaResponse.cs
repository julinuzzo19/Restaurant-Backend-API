using System;

namespace Domain.DTOs
{
    public class ComandaResponse
    {
        public Guid ComandaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreMercaderia { get; set; }

        public int FormaEntregaId { get; set; }
        public string FormaEntrega { get; set; }
        public int MercaderiaId { get; set; }
    }
}