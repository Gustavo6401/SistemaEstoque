using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estoque.Infra.Contexto;
using Estoque.Infra.Repositories.Base;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;

namespace Estoque.Infra.Repositories
{
    public class EquipamentoRepository : Repository<Equipamento>, IEquipamentoRepository
    {
        EstoqueContext Db = new EstoqueContext();

        public Equipamento GetById(int id) => Db.Equipamento.FirstOrDefault(t => t.Id == id);

        public Equipamento ProcurarPorNome(string nome) => Db.Equipamento.FirstOrDefault(t => t.Nome.Equals(nome));

        IAsyncEnumerable<Equipamento> IEquipamentoRepository.ProcurarPorQtd(int qtd) => Db.Equipamento.Where(t => t.QtdEstoque.Equals(qtd))
                                                                                                      .AsAsyncEnumerable();              
    }
}
