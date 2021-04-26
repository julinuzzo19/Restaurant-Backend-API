using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class ComandaResponseCreated
    {
        public Guid ComandaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public int FormaEntregaId { get; set; }
        public List<string> Mercaderia { get; set; }
    }
}
