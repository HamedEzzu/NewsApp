using NewsApp2.Models.Interfaces;
using NewsApp2.Models.Repositories;

namespace NewsApp2.Models.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private IGRepository<T> _entity;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GRepository<T>(_context));
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
