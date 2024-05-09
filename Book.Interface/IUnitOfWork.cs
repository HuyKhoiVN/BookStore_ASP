using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Interface
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IGenericRepository<T> Entity { get; }
        Task CompleteAsync();
    }
}
