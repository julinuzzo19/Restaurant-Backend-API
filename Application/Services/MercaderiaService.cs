
using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IMercaderiaService
    {
        MercaderiaResponse CreateMercaderia(MercaderiaDTO mercaderia);
        List<MercaderiaResponse> GetAll(string tipoMercaderia, int tipoMercaderiaId);
        void UpdateMercaderia(int MercaderiaId, MercaderiaDTO mercaderiaDTO);
        MercaderiaResponse GetMercaderiaById(int Id);
        void DeleteMercaderiaById(int MercaderiaId);
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

        public void DeleteMercaderiaById(int MercaderiaId)
        {
            MercaderiaResponse mercaderiaReponse = _queriesMercaderia.GetMercaderiaById(MercaderiaId);

            if (mercaderiaReponse == null)
            {
                throw new Exception();
            }

            Mercaderia mercaderia = new Mercaderia
            {
                MercaderiaId = mercaderiaReponse.MercaderiaId,
                Nombre = mercaderiaReponse.Nombre,
                Precio = mercaderiaReponse.Precio,
                Ingredientes = mercaderiaReponse.Ingredientes,
                Preparación = mercaderiaReponse.Preparación,
                Imagen = mercaderiaReponse.Imagen,
                TipoMercaderiaId = mercaderiaReponse.TipoMercaderiaId
            };

            _repository.Delete<Mercaderia>(mercaderia);
            _repository.SaveChanges();
        }

        public List<MercaderiaResponse> GetAll(string tipoMercaderia, int tipoMercaderiaId)
        {
            return _queriesMercaderia.GetAll(tipoMercaderia, tipoMercaderiaId);
        }

        public MercaderiaResponse GetMercaderiaById(int Id)
        {
            return _queriesMercaderia.GetMercaderiaById(Id);
        }

        public void UpdateMercaderia(int MercaderiaId, MercaderiaDTO mercaderiaDTO)
        {
            Mercaderia mercaderia = new Mercaderia
            {
                MercaderiaId = MercaderiaId,
                Nombre = mercaderiaDTO.Nombre,
                Precio = mercaderiaDTO.Precio,
                Ingredientes = mercaderiaDTO.Ingredientes,
                Preparación = mercaderiaDTO.Preparación,
                Imagen = mercaderiaDTO.Imagen,
                TipoMercaderiaId = mercaderiaDTO.TipoMercaderiaId

            };

            _repository.Update<Mercaderia>(mercaderia);
            _repository.SaveChanges();
        }
    }
}
