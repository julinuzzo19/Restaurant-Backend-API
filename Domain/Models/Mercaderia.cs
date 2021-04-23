using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Mercaderia
    {
        [Required] public int MercaderiaId { get; set; }
        [Required] public string Nombre { get; set; }
        [Required] public int Precio { get; set; }
        [Required] public string Ingredientes { get; set; }
        [Required] public string Preparación { get; set; }
        [Required] public string Imagen { get; set; }

        //FK
        [Required] public int TipoMercaderiaId { get; set; }
        [ForeignKey("TipoMercaderiaId")]
        public virtual TipoMercaderia TipoMercaderia { get; set; }


    }
}
