using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class ComandaMercaderia
    {
        [Required] public int ComandaMercaderiaId { get; set; }

        //FK
        [Required] public Guid ComandaId { get; set; }
        [ForeignKey("ComandaId")] [Required] public Comanda Comanda { get; set; }

        [Required] public int MercaderiaId { get; set; }
        [ForeignKey("MercaderiaId")] [Required] public Mercaderia Mercaderia { get; set; }


    }
}
