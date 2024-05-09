using Books.Data.Persistence;
using Books.Data.Repository;
using Books.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.UnitOfWork
{
#nullable disable
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        public IGenericRepository<T> _entity;
        private bool _disposed;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IGenericRepository<T> Entity
        {
            get
            {
                return _entity ??= new GenericRepository<T>(_dbContext);
            }
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
