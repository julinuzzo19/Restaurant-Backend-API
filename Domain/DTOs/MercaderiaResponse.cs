namespace Domain.DTOs
{
    public class MercaderiaResponse
    {
        public int MercaderiaId { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparación { get; set; }
        public string Imagen { get; set; }
        public int TipoMercaderiaId { get; set; }
    }
}
