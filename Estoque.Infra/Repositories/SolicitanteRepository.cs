using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Infra.Contexto;
using Estoque.Infra.Repositories.Base;

namespace Estoque.Infra.Repositories
{
    public class SolicitanteRepository : Repository<Solicitante>, ISolicitanteRepository
    {
        EstoqueContext Db = new EstoqueContext();

        public Solicitante GetById(int id) => Db.Solicitante.FirstOrDefault(t => t.Id == id);

        public Solicitante ProcurarPorNome(string nome) => Db.Solicitante.FirstOrDefault(t => t.Nome.Contains(nome));
    }
}
