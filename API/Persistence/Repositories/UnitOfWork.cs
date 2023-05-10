using API.Application.Repositories;
using API.Domain.Entities;
using API.Persistence.Context;

namespace API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;

        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
            ProductRepository = new BaseRepository<Product>(_context);
        }

        public IBaseRepository<Product> ProductRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
