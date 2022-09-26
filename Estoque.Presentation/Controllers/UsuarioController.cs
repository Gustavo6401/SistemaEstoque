using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;
using Estoque.Services.Criptografia;

namespace Estoque.Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Create", "Acesso");
                }
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string nome, string senha)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = await client.GetStringAsync($"http://localhost:5065/api/Usuario/nome?nome={nome}&password?password={senha}");

                Models.Usuario usuario = JsonConvert.DeserializeObject<Models.Usuario>(json);

                if (usuario != null)
                {
                    List<Claim> direitosAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, nome),
                    new Claim(ClaimTypes.Name, nome)
                };

                    var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
                    var userPrincipal = new ClaimsPrincipal(new[] { identity });

                    await HttpContext.SignInAsync(userPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTime.Now.AddDays(7)
                        });

                    return RedirectToAction("Create", "Acesso");
                }
                ViewBag.Message = "Usuário Não Encontrado! Tente Novamente!";

                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    await HttpContext.SignOutAsync();
                }
                return RedirectToAction("Edit", "Acesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Senha")] Usuario usuario)
        {
            try
            {
                HashMD5 mD5 = new HashMD5();
                usuario.Senha = mD5.Criptografar(usuario.Senha);

                UsuarioRepository repository = new UsuarioRepository();
                repository.Add(usuario);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
