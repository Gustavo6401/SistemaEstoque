using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Infra.Contexto;
using Estoque.Infra.Repositories.Base;

namespace Estoque.Infra.Repositories
{
    public class MaquinaSolicitadaRepository : Repository<MaquinaSolicitada>, IMaquinaSolicitadaRepository
    {
        EstoqueContext Db = new EstoqueContext();
        public MaquinaSolicitada GetMaquinaSolicitada(int id) => Db.MaquinaSolicitada.FirstOrDefault(x => x.Id == id);
    }
}
