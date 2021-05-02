using Domain.DTOs;
using System.Collections.Generic;

namespace Domain.Queries
{
    public interface IMercaderiaQueries
    {
        MercaderiaResponse GetMercaderiaById(int id);
        List<MercaderiaResponse> GetAll(string tipoMercaderia, int TipoMercaderiaId);
    }
}