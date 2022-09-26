using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        [HttpGet]
        public async Task<IAsyncEnumerable<Solicitacao>> GetSolicitacao()
        {
            SolicitacaoRepository repository = new SolicitacaoRepository();
            return repository.Get();
        }
    }
}
