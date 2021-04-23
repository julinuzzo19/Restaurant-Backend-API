using Domain.Commands;
using Domain.Models;
using System;

namespace Application.Services
{
    public interface IComandaService
    {
        void CreateComanda();
        Comanda GetAll(DateTime? Fecha);
        Comanda GetComandaById(Guid Id);
    }

    public class ComandaService : IComandaService
    {
        private readonly IGenericRepository _repository;
        //private readonly ComandaQueries _queriesComanda;


        public ComandaService(IGenericRepository repository)//, ComandaQueries queriesComanda
        {
            _repository = repository;
            //_queriesComanda = queriesComanda;

        }


        public void CreateComanda()
        {

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
