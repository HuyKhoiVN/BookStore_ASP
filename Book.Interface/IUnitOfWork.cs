using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Interface
{
    public interface IUnitOfWork<T> : IDbInitializer where T : class
    {
        IGenericRepository<T> Repository { get; }
        Task CompleteAsync();
    }
}
