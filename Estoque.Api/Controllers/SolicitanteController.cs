using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitanteController : ControllerBase
    {
        [HttpGet]
        public async Task<IAsyncEnumerable<Solicitante>> GetSolicitante()
        {
            SolicitanteRepository repository = new SolicitanteRepository();
            return repository.Get();
        }

        [HttpGet("id")]
        public async Task<Solicitante> GetSolicitanteById(int id)
        {
            SolicitanteRepository repository = new SolicitanteRepository();
            return repository.GetById(id);
        }

        [HttpGet("nome")]
        public async Task<Solicitante> GetSolicitanteByName(string name)
        {
            SolicitanteRepository repository = new SolicitanteRepository();
            return repository.ProcurarPorNome(name);
        }

        [HttpPost]
        public async Task<ActionResult<Solicitante>> PostSolicitante(Solicitante solicitante)
        {
            SolicitanteRepository repository = new SolicitanteRepository();
            repository.Add(solicitante);

            return CreatedAtAction("GetSolicitante", new { id = solicitante.Id }, solicitante);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutSolicitante(int id, Solicitante solicitante)
        {
            SolicitanteRepository repository = new SolicitanteRepository();

            Solicitante sol = new Solicitante();
            sol = repository.GetById(id);

            sol.Nome = solicitante.Nome;

            repository.Update(sol);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSolicitante(int id)
        {
            SolicitanteRepository repository = new SolicitanteRepository();
            Solicitante solicitante = repository.GetById(id);

            repository.Delete(solicitante);

            return NoContent();
        }
    }
}
