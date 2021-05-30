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

        public List<Comanda> GetAll(DateTime? Fecha)
        {
            if (Fecha == null)
            {
                var query = database.Query("Comanda");

                var result = query.Get<Comanda>().ToList();

                return result;
            }
            else
            {
                var query = database.Query("Comanda")
                .WhereDate("Comanda.Fecha", "=", Fecha);

                var result = query.Get<Comanda>().ToList();

                return result;
            }
        }

        public ComandaConMercaderiaList GetComandaById(Guid id)
        {
            var query = database.Query("Comanda").Select("*").Select("FormaEntrega.Descripcion as FormaEntrega").
                Join("FormaEntrega", "FormaEntrega.FormaEntregaId", "Comanda.FormaEntregaId")
                .Where("Comanda.ComandaId", "=", id)
                .FirstOrDefault<ComandaConMercaderiaList>();

            return query;
        }

        public List<ComandaResponse> GetMercaderiasByComandaId(Guid id)
        {
            var query = database.Query("Comanda").Select("*")
                .Select("FormaEntrega.Descripcion as FormaEntrega", "Mercaderia.Nombre as NombreMercaderia")
                .Join("ComandaMercaderia", "ComandaMercaderia.ComandaId", "Comanda.ComandaId")
                .Join("Mercaderia", "Mercaderia.MercaderiaId", "ComandaMercaderia.MercaderiaId")
                .Join("FormaEntrega", "FormaEntrega.FormaEntregaId", "Comanda.FormaEntregaId")
                .Where("Comanda.ComandaId", "=", id);

            var result = query.Get<ComandaResponse>().ToList();

            return result;
        }
    }
}