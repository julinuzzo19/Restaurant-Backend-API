using Domain.DTOs;
using Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;
using System.Linq;

namespace AccessData.Queries
{
    public class MercaderiaQueries : IMercaderiaQueries
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly QueryFactory database;

        public MercaderiaQueries(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            database = new QueryFactory(connection, sqlKataCompiler);
        }

        public MercaderiaResponse GetMercaderiaById(int id)
        {
            var query = database.Query("Mercaderia").Where("Mercaderia.MercaderiaId", "=", id).FirstOrDefault<MercaderiaResponse>();

            return query;
        }


    }
}
