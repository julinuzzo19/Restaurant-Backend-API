using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Queries
{
    public interface IComandaQueries
    {
        ComandaResponse GetComandaById(Guid id);
        List<ComandaResponse> GetAll(DateTime? Fecha);
    }
}
