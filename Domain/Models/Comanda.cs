using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Comanda
    {
        [Required] public Guid ComandaId { get; set; }
        [Required] public int PrecioTotal { get; set; }
        [Required] public DateTime Fecha { get; set; }

        //FK
        [Required] public int FormaEntregaId { get; set; }
        [ForeignKey("FormaEntregaId")]
        public virtual FormaEntrega FormaEntrega { get; set; }

    }
}
