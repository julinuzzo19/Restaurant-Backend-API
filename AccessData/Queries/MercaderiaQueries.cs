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
            var query = database.Query("Mercaderia").Select("*").Select("TipoMercaderia.Descripcion as TipoMercaderia")
            .Join("TipoMercaderia", "Mercaderia.TipoMercaderiaId", "TipoMercaderia.TipoMercaderiaId").
                Where("Mercaderia.MercaderiaId", "=", id).FirstOrDefault<MercaderiaResponse>();

            return query;
        }

        public List<MercaderiaResponse> GetAll(int TipoMercaderiaId)
        {
            if (TipoMercaderiaId == 0)
            {
                var query = database.Query("Mercaderia").Select("*").Select("TipoMercaderia.Descripcion as TipoMercaderia")
                .Join("TipoMercaderia", "Mercaderia.TipoMercaderiaId", "TipoMercaderia.TipoMercaderiaId");

                var result = query.Get<MercaderiaResponse>().ToList();

                return result;
            }
            else
            {
                var query = database.Query("Mercaderia").Select("*").Select("TipoMercaderia.Descripcion as TipoMercaderia")
                .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderia.TipoMercaderiaId")
                .Where("Mercaderia.TipoMercaderiaId", "=", TipoMercaderiaId);

                var result = query.Get<MercaderiaResponse>().ToList();

                return result;
            }
        }
    }
}