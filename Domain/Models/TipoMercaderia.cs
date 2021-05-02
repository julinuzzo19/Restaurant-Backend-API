using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class TipoMercaderia
    {
        [Required] public int TipoMercaderiaId { get; set; }
        [Required] public string Descripcion { get; set; }
    }
}