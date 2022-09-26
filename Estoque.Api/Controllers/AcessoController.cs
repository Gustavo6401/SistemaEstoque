using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        public async Task<IAsyncEnumerable<Acesso>> GetAcesso()
        {
            AcessoRepository repository = new AcessoRepository();
            return repository.Get();
        }

        [HttpGet("usuarioId")]
        public async Task<Acesso> GetAcessoByUsuarioId(int usuarioId) 
        {
            AcessoRepository repository = new AcessoRepository();
            return repository.ProcurarAcesso(usuarioId);
        }


        [HttpPost]
        public async Task<ActionResult<Acesso>> PostAcesso(Acesso acesso)
        {
            acesso.Usuario = null;

            AcessoRepository repository = new AcessoRepository();
            repository.Add(acesso);

            return CreatedAtAction("GetAcesso", new { id = acesso.Id }, acesso);
        }

        [HttpPut]
        public async Task<ActionResult<Acesso>> PutAcesso(Acesso acesso) 
        {
            AcessoRepository repository = new AcessoRepository();

            Acesso model = repository.GetById(acesso.Id);
            model.UsuarioId = acesso.UsuarioId;
            model.Hora = acesso.Hora;
            model.Final = DateTime.Now;
            model.Usuario = null;

            repository.Update(model);

            return NoContent();
        }
    }
}
