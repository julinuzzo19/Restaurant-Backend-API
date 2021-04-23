using AccessData.Queries;
using Domain.Commands;
using Domain.Models;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IMercaderiaService
    {
        void CreateMercaderia();
        List<Mercaderia> GetAll(int? TipoMercaderiaId);
        void UpdateMercaderia(int Id);
        Mercaderia GetMercaderiaById(int Id);
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

        public List<Mercaderia> GetAll(int? TipoMercaderiaId)
        {
            throw new System.NotImplementedException();
        }

        public Mercaderia GetMercaderiaById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMercaderia(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
