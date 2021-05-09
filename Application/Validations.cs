using Domain.DTOs;

namespace Application
{
    public class Validation
    {
        public static bool ValidarMercaderiaDTO(MercaderiaDTO mercaderia)
        {
            if (!string.IsNullOrWhiteSpace(mercaderia.Imagen) && !string.IsNullOrWhiteSpace(mercaderia.Ingredientes) && !string.IsNullOrWhiteSpace(mercaderia.Nombre) && !string.IsNullOrWhiteSpace(mercaderia.Preparación) && mercaderia.Precio > 0
                && (mercaderia.TipoMercaderiaId > 0))
            {
                return true;
            }

            return false;
        }

        public static bool ValidarComandaDTO(ComandaDTO comanda)
        {
            if (comanda.FormaEntrega > 0 && comanda.MercaderiasId.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}