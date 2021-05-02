using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class ComandaConMercaderiaList
    {
        public Guid ComandaId { get; set; }
        public int PrecioTotal { get; set; }
        public string Fecha { get; set; }
        public int FormaEntregaId { get; set; }
        public List<string> NombreMercaderia { get; set; }
    }
}