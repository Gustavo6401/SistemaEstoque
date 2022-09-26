using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Infra.Contexto;
using Estoque.Domain.Interfaces.Repositories.Base;

namespace Estoque.Infra.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        EstoqueContext Db = new EstoqueContext();
        public void Add(T item)
        {
            Db.Set<T>().Add(item);

            Db.SaveChangesAsync();
        }

        public void Delete(T item)
        {
            Db.Set<T>().Remove(item);

            Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<T> Get() => Db.Set<T>().AsAsyncEnumerable();

        public void Update(T item)
        {
            Db.Modify(item);

            Db.SaveChangesAsync();
        }
    }
}
