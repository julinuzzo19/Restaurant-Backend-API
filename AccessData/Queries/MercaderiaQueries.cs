using Domain.DTOs;
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

        public MercaderiaResponse GetMercaderiaById(int id)
        {
            var query = database.Query("Mercaderia").Where("Mercaderia.MercaderiaId", "=", id).FirstOrDefault<MercaderiaResponse>();

            return query;
        }

        public List<MercaderiaResponse> GetAll(string TipoMercaderia)
        {
            if (string.IsNullOrWhiteSpace(TipoMercaderia))
            {
                var query = database.Query("Mercaderia");

                var result = query.Get<MercaderiaResponse>().ToList();

                return result;
            }

            else
            {
                var query = database.Query("Mercaderia")
                    .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderia.TipoMercaderiaId")
                    .WhereRaw($"TipoMercaderia.Descripcion like '%{TipoMercaderia}%'", "sql");


                var result = query.Get<MercaderiaResponse>().ToList();

                return result;
            }


            throw new System.NotImplementedException();
        }


    }
}
