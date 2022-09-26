using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Estoque.Presentation.Models;

namespace Estoque.Presentation.Controllers
{
    public class AcessoController : Controller
    {
        public IActionResult Index() => View();

        public ActionResult Create() => View();

        public ActionResult Edit() => View();

        public ActionResult Delete() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,Hora,Final")] Acesso acesso, string user, string senha)
        {
            try
            {
                HttpClient client = new HttpClient();

                string jsonUsuario = await client.GetStringAsync($"http://localhost:5065/api/Usuario/nome&password?nome={user}&password={senha}");

                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonUsuario);

                acesso.UsuarioId = usuario.Id;
                acesso.Usuario = usuario;

                if (usuario != null)
                {
                    List<Claim> direitosAcesso = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user),
                        new Claim(ClaimTypes.Name, user)
                    };

                    var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
                    var userPrincipal = new ClaimsPrincipal(new[] { identity });

                    await HttpContext.SignInAsync(userPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTime.Now.AddHours(1)
                        }); ;

                    acesso.Hora = DateTime.Now;

                    string json = JsonConvert.SerializeObject(acesso);
                    StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

                    var resp = client.PostAsync("http://localhost:5065/api/Acesso", body).Result;

                    return RedirectToAction("Index", "Home");
                }               

                return View();
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,UsuarioId,Hora,Final")] Acesso acesso, string nome, string password)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Consulta e Carrega os Dados de Usuário.
                string jsonUsuario = client.GetAsync($"http://localhost:5065/api/Usuario/nome&password?nome={nome}&password={password}").Result.Content.ReadAsStringAsync().Result;

                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonUsuario);

                // Pelo Id do usuário, o programa busca na API o último acesso.
                string jsonAcesso = client.GetAsync($"http://localhost:5065/api/Acesso/usuarioId?usuarioId={usuario.Id}").Result.Content.ReadAsStringAsync().Result;

                Acesso model = JsonConvert.DeserializeObject<Acesso>(jsonAcesso);
                // Ao menos aqui, o usuário não pode ser nulo.
                model.Usuario = usuario;

                acesso = model;

                // Eu pego os dados recebidos para jogar na minha api novamente
                string json = JsonConvert.SerializeObject(acesso);
                StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = client.PutAsync($"http://localhost:5065/api/Acesso", body).Result;

                if (User.Identity.IsAuthenticated)
                {
                    await HttpContext.SignOutAsync();
                }

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }
    }
}
