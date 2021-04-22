using Domain.Models;
using System;

namespace Domain.Queries
{
    public interface IComandaQueries
    {
        Comanda GetComandaById(Guid id);
    }
}
