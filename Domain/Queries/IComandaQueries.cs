using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Queries
{
    public interface IComandaQueries
    {
        Comanda GetComandaById(Guid id);
        List<Comanda> GetAll(DateTime? Fecha);
        List<ComandaResponse> GetMercaderiasByComandaId(Guid id);
    }
}
