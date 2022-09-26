using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces.Repositories
{
    public interface IEquipamentoRepository
    {
        public Equipamento ProcurarPorNome(string nome);
        public IAsyncEnumerable<Equipamento> ProcurarPorQtd(int qtd);
        public Equipamento GetById(int id);
    }
}
