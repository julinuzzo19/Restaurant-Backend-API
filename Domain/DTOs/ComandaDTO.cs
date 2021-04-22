using System;

namespace Domain.DTOs
{
    public class ComandaDTO
    {
        public Guid ComandaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }//Forma entrega

    }
}
