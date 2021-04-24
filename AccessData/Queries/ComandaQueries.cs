using Domain.DTOs;
using Domain.Models;
using Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AccessData.Queries
{
    public class ComandaQueries : IComandaQueries
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly QueryFactory database;

        public ComandaQueries(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            database = new QueryFactory(connection, sqlKataCompiler);
        }

        public List<ComandaResponse> GetAll(DateTime? Fecha)
        {
            if (Fecha == null)
            {
                var query = database.Query("Comanda");               

               var result= query.Get<ComandaResponse>().ToList();

                return result;
            }
            else
            {
                var query = database.Query("Comanda")
                    .WhereDate("Comanda.Fecha","=",Fecha);

                var result = query.Get<ComandaResponse>().ToList();

                return result;
            }
        }

        public ComandaResponse GetComandaById(Guid id)
        {
            var query = database.Query("Comanda")
                .Where("Comanda.ComandaId","=",id)            
                .FirstOrDefault<ComandaResponse>();
            //    .Select("FormaEntregaId as FormaEntrega, ComandaId,Fecha,PrecioTotal")
            //.Where("Comanda.ComandaId", "=", id).FirstOrDefault<ComandaResponse>();

            //var result = query.Get<ComandaResponse>();
            
            return query;
        }

       
    }
}
