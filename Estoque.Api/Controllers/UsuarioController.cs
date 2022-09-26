using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;
using Estoque.Services.Criptografia;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<IAsyncEnumerable<Usuario>> GetUsuario() 
        {
            UsuarioRepository repository = new UsuarioRepository();
            return repository.Get();
        }

        [HttpGet("nome&password")]
        public async Task<Usuario> GetLogin(string nome, string password)
        {
            HashMD5 md5 = new HashMD5();
            password = md5.Criptografar(password);

            UsuarioRepository repository = new UsuarioRepository();
            return repository.Login(nome, password);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostLogin(Usuario usuario)
        {
            HashMD5 md5 = new HashMD5();
            usuario.Senha = md5.Criptografar(usuario.Senha);

            UsuarioRepository repository = new UsuarioRepository();
            repository.Add(usuario);

            return NoContent();
        }
    }
}
