using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class FormaEntrega
    {
        [Required] public int FormaEntregaId { get; set; }
        [Required] public string Descripcion { get; set; }
    }
}