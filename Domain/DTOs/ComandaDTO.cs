using System.Collections.Generic;

namespace Domain.DTOs
{
    public class ComandaDTO
    {
        public int FormaEntrega { get; set; }
        public List<int> Mercaderia { get; set; }
    }
}