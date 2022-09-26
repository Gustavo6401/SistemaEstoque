using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> : IDisposable where T : class
    {
        public IAsyncEnumerable<T> Get();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
