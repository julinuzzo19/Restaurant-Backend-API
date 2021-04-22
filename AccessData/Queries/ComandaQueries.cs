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

        public Comanda GetComandaById(Guid id)
        {
            var query = database.Query("Comanda")
            .Where("Comanda.ComandaId", "=", id).FirstOrDefault<Comanda>();

            return query;
        }


        public List<MercaderiasComandaDTO> GetMercaderiasByComandaId(Guid id)
        {
            var query = database.Query("Comanda")
                .SelectRaw("Comanda.ComandaId ,Comanda.Fecha ,Comanda.PrecioTotal,Mercaderia.Nombre ,TipoMercaderia.Descripcion as TipoMercaderia,TipoMercaderia.TipoMercaderiaId")
            .Join("ComandaMercaderia", "ComandaMercaderia.ComandaId", "Comanda.ComandaId")
            .Join("Mercaderia", "Mercaderia.MercaderiaId", "ComandaMercaderia.MercaderiaId")
            .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderia.TipoMercaderiaId")
            .Where("Comanda.ComandaId", "=", id);

            var result = query.Get<MercaderiasComandaDTO>().ToList();

            return result;
        }
    }
}
