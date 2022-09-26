using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Infra.Contexto;
using Estoque.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infra.Repositories
{
    public class AcessoRepository : Repository<Acesso>, IAcessoRepository
    {
        EstoqueContext Db = new EstoqueContext();

        public Acesso GetById(int id) => Db.Acesso.FirstOrDefault(t => t.Id ==  id);

        public Acesso ProcurarAcesso(int id) => Db.Acesso.OrderBy(t => t.Hora)
                                                         .ToList()
                                                         .LastOrDefault(t => t.UsuarioId.Equals(id));

        public IAsyncEnumerable<Acesso> ProcurarPorDataAcesso(DateTime date) => Db.Acesso.Where(t => t.Hora.Equals(date))
                                                                                         .AsAsyncEnumerable();
    }
}
