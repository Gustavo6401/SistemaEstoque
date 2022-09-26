using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces.Repositories
{
    public interface ISolicitanteRepository
    {
        public Solicitante ProcurarPorNome(string nome);
        public Solicitante GetById(int id);
    }
}
