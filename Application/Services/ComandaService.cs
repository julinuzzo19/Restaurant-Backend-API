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
        ComandaResponseCreated CreateComanda(ComandaDTO comandaDTO);
        List<ComandaConMercaderiaList> GetAll(string Fecha);
        ComandaResponseCreated GetComandaById(Guid Id);
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

        public ComandaResponseCreated CreateComanda(ComandaDTO comandaDTO)
        {
            Comanda Comanda = new Comanda
            {
                ComandaId = Guid.NewGuid(),
                Fecha = DateTime.Now,
                FormaEntregaId = comandaDTO.FormaEntrega
            };

            int PrecioTotal = 0;
            List<string> ListaMercaderia = new List<string>();

            foreach (var item in comandaDTO.MercaderiasId)
            {
                MercaderiaResponse mercaderia = _queriesMercaderia.GetMercaderiaById(item);
                if (mercaderia != null)
                {
                    PrecioTotal = PrecioTotal + mercaderia.Precio;
                    ListaMercaderia.Add(mercaderia.Nombre);
                    ComandaMercaderia relacion = new ComandaMercaderia { ComandaId = Comanda.ComandaId, MercaderiaId = mercaderia.MercaderiaId };
                    _repository.Add<ComandaMercaderia>(relacion);
                }
                else { throw new Exception(); }
            }
            Comanda.PrecioTotal = PrecioTotal;

            if (ListaMercaderia.Count == 0)
            {
                throw new Exception();
            }

            _repository.Add<Comanda>(Comanda);
            _repository.SaveChanges();

            return new ComandaResponseCreated
            {
                ComandaId = Comanda.ComandaId,
                PrecioTotal = Comanda.PrecioTotal,
                Fecha = Comanda.Fecha,
                FormaEntregaId = Comanda.FormaEntregaId,
                Mercaderia = ListaMercaderia
            };
        }

        public List<ComandaConMercaderiaList> GetAll(string Fecha)
        {
            List<Comanda> comandas;
            List<ComandaConMercaderiaList> comandasMercaderiaList = new List<ComandaConMercaderiaList>();

            if (Fecha != null)
            {
                DateTime fecha = Convert.ToDateTime(Fecha);
                comandas = _queriesComanda.GetAll(fecha);
            }
            else
            {
                comandas = _queriesComanda.GetAll(null);
            }

            //Recorro las comandas obtenidas
            foreach (var comanda in comandas)
            {
                List<ComandaResponse> ListMercaderiaByComanda = _queriesComanda.GetMercaderiasByComandaId(comanda.ComandaId);
                List<string> NombreMercaderiaList = new List<string>();

                //Creo una lista con los nombres de todas las mercaderias de una comanda
                foreach (var item in ListMercaderiaByComanda)
                {
                    NombreMercaderiaList.Add(item.NombreMercaderia);
                }

                //Creo la comanda a retornar con la lista de mercaderia
                ComandaConMercaderiaList comandaMercaderia = new ComandaConMercaderiaList
                {
                    ComandaId = comanda.ComandaId,
                    Fecha = comanda.Fecha.ToString(),
                    PrecioTotal = comanda.PrecioTotal,
                    FormaEntregaId = comanda.FormaEntregaId,
                    NombreMercaderia = NombreMercaderiaList
                };

                comandasMercaderiaList.Add(comandaMercaderia);
            }

            return comandasMercaderiaList;
        }

        public ComandaResponseCreated GetComandaById(Guid Id)
        {
            Comanda comanda = _queriesComanda.GetComandaById(Id);
            if (comanda == null)
            {
                throw new Exception();
            }
            List<ComandaResponse> ListMercaderiaByComanda = _queriesComanda.GetMercaderiasByComandaId(comanda.ComandaId);

            List<string> ListaMercaderia = new List<string>();

            foreach (var item in ListMercaderiaByComanda)
            {
                ListaMercaderia.Add(item.NombreMercaderia);
            }

            return new ComandaResponseCreated
            {
                ComandaId = comanda.ComandaId,
                PrecioTotal = comanda.PrecioTotal,
                Fecha = comanda.Fecha,
                FormaEntregaId = comanda.FormaEntregaId,
                Mercaderia = ListaMercaderia
            };
        }
    }
}