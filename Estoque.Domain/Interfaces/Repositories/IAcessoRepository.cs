using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces.Repositories
{
    public interface IAcessoRepository
    {
        public IAsyncEnumerable<Acesso> ProcurarPorDataAcesso(DateTime date);
        public Acesso ProcurarAcesso(int id);
        public Acesso GetById(int id);
    }
}
