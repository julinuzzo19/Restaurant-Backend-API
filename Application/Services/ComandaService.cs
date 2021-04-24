using Domain.Commands;
using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IComandaService
    {
        ComandaResponse CreateComanda(ComandaDTO comandaDTO);
        Comanda GetAll(DateTime? Fecha);
        Comanda GetComandaById(Guid Id);
    }

    public class ComandaService : IComandaService
    {
        private readonly IGenericRepository _repository;
        private readonly IComandaQueries _queriesComanda;
        private readonly IMercaderiaQueries _queriesMercaderia;

        public ComandaService(IGenericRepository repository, IComandaQueries queriesComanda, IMercaderiaQueries queriesMercaderia)
        {
            _repository = repository;
            _queriesComanda = queriesComanda;
            _queriesMercaderia = queriesMercaderia;
        }


        public ComandaResponse CreateComanda(ComandaDTO comandaDTO)
        {
            Comanda Comanda = new Comanda
            {
                ComandaId = Guid.NewGuid(),
                Fecha = DateTime.Now,
                FormaEntregaId = comandaDTO.FormaEntrega
            };

            int PrecioTotal = 0;
            List<string> ListaMercaderia =new List<string>();

            foreach (var item in comandaDTO.MercaderiasId)
            {
                Mercaderia mercaderia = _queriesMercaderia.GetMercaderiaById(item);
                PrecioTotal = PrecioTotal + mercaderia.Precio;
                ListaMercaderia.Add(mercaderia.Nombre);

                ComandaMercaderia relacion = new ComandaMercaderia { ComandaId = Comanda.ComandaId, MercaderiaId = mercaderia.MercaderiaId };
                _repository.Add<ComandaMercaderia>(relacion);
            }
            Comanda.PrecioTotal = PrecioTotal;
           
            _repository.Add<Comanda>(Comanda);
            _repository.SaveChanges();

            return new ComandaResponse 
            {
                ComandaId=Comanda.ComandaId,
                PrecioTotal=Comanda.PrecioTotal,
                Fecha=Comanda.Fecha,
                FormaEntrega=Comanda.FormaEntregaId,
                Mercaderia=ListaMercaderia       
            };
  
        }

        public Comanda GetAll(DateTime? Fecha)
        {
            throw new NotImplementedException();
        }

        public Comanda GetComandaById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
