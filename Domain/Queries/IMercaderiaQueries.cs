using Domain.DTOs;

namespace Domain.Queries
{
    public interface IMercaderiaQueries
    {
        MercaderiaResponse GetMercaderiaById(int id);
    }
}
