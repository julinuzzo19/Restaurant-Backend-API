using AccessData.Queries;
using Domain.Commands;

namespace Application.Services
{
    public interface IMercaderiaService
    {
        void CreateMercaderia();
    }

    public class MercaderiaService : IMercaderiaService
    {
        private readonly IGenericRepository _repository;
        private readonly MercaderiaQueries _queriesMercaderia;

        public MercaderiaService(IGenericRepository repository, MercaderiaQueries queriesMercaderia)
        {
            _repository = repository;
            _queriesMercaderia = queriesMercaderia;

        }

        public void CreateMercaderia()
        {

        }
    }
}
