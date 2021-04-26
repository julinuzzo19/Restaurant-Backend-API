
using Domain.Commands;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Commands
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext DatabaseContext)
        {
            _context = DatabaseContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
