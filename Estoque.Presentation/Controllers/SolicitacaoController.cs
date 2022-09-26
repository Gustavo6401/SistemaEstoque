using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Estoque.Presentation.Models;

namespace Estoque.Presentation.Controllers
{
    public class SolicitacaoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = client.GetAsync("http://localhost:5065/api/Solicitacao").Result.Content.ReadAsStringAsync().Result;

                List<Solicitacao> lista = JsonConvert.DeserializeObject<List<Solicitacao>>(json).ToList();

                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }
    }
}
