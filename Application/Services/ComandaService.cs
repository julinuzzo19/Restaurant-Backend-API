using AccessData.Queries;
using Domain.Commands;

namespace Application.Services
{
    public interface IComandaService
    {
        void RegistrarComanda();
        void ListarComandas();
    }

    public class ComandaService : IComandaService
    {
        private readonly IGenericRepository _repository;
        private readonly ComandaQueries _queriesComanda;


        public ComandaService(IGenericRepository repository, ComandaQueries queriesComanda)
        {
            _repository = repository;
            _queriesComanda = queriesComanda;

        }


        public void RegistrarComanda()
        {

        }

        public void ListarComandas()
        {

        }
    }
}
