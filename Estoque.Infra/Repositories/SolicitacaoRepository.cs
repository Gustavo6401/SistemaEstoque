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
    public class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
    {
        EstoqueContext Db = new EstoqueContext();
        public IAsyncEnumerable<Solicitacao> GetSolicitacaos(string nomeEquipamento, int qtdSolicitada, string nomeSolicitante) => Db.Solicitacao.Where(t => t.NomeEquipamento.Contains(nomeEquipamento)
                                                                                                                                                        || t.QtdSolicitada.Equals(qtdSolicitada)
                                                                                                                                                        || t.NomeSolicitante.Contains(nomeSolicitante))
                                                                                                                                                 .AsAsyncEnumerable();
    }
}
