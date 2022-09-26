using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaSolicitadaController : ControllerBase
    {
        [HttpGet]
        public async Task<IAsyncEnumerable<MaquinaSolicitada>> GetSolicitacao() 
        {
            MaquinaSolicitadaRepository repository = new MaquinaSolicitadaRepository();
            return repository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<MaquinaSolicitada>> PostSolicitacao(MaquinaSolicitada maquina)
        {
            maquina.Equipamento = null;
            maquina.Solicitante = null;
            
            MaquinaSolicitadaRepository repository = new MaquinaSolicitadaRepository();
            repository.Add(maquina);

            return CreatedAtAction("GetSolicitacao", new { id = maquina.Id }, maquina);
        }
    }
}
