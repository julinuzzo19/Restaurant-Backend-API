using Domain.Models;
using Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
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

        public List<Mercaderia> ListarMercaderia()
        {
            var query = database.Query("Mercaderia");
            var result = query.Get<Mercaderia>().ToList();

            return result;
        }

        public Mercaderia GetMercaderiaById(int id)
        {
            var query = database.Query("Mercaderia").Where("Mercaderia.MercaderiaId", "=", id).FirstOrDefault<Mercaderia>();

            return query;
        }


    }
}
