
using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IMercaderiaService
    {
        MercaderiaResponse CreateMercaderia(MercaderiaDTO mercaderia);
        List<Mercaderia> GetAll(int? TipoMercaderiaId);
        void UpdateMercaderia(int Id);
        MercaderiaResponse GetMercaderiaById(int Id);
    }

    public class MercaderiaService : IMercaderiaService
    {
        private readonly IGenericRepository _repository;
        private readonly IMercaderiaQueries _queriesMercaderia;

        public MercaderiaService(IGenericRepository repository, IMercaderiaQueries queriesMercaderia)
        {
            _repository = repository;
            _queriesMercaderia = queriesMercaderia;

        }

        public MercaderiaResponse CreateMercaderia(MercaderiaDTO mercaderia)
        {
            Mercaderia Mercaderia = new Mercaderia
            {
                Nombre = mercaderia.Nombre,
                TipoMercaderiaId = mercaderia.TipoMercaderiaId,
                Precio = mercaderia.Precio,
                Imagen = mercaderia.Imagen,
                Preparación = mercaderia.Preparación,
                Ingredientes = mercaderia.Ingredientes
            };

            _repository.Add<Mercaderia>(Mercaderia);
            _repository.SaveChanges();

            return new MercaderiaResponse
            {
                MercaderiaId = Mercaderia.MercaderiaId,
                Nombre = Mercaderia.Nombre,
                TipoMercaderiaId = Mercaderia.TipoMercaderiaId,
                Precio = Mercaderia.Precio,
                Imagen = Mercaderia.Imagen,
                Preparación = Mercaderia.Preparación,
                Ingredientes = Mercaderia.Ingredientes
            };
        }

        public List<Mercaderia> GetAll(int? TipoMercaderiaId)
        {
            throw new System.NotImplementedException();
        }

        public MercaderiaResponse GetMercaderiaById(int Id)
        {
            return _queriesMercaderia.GetMercaderiaById(Id);
        }

        public void UpdateMercaderia(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
