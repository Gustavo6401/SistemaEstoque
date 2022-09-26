using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Estoque.Presentation.Models;

namespace Estoque.Presentation.Controllers
{
    // GUSTAVO ESTEVE AQUI!!!!
    public class SolicitanteController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = client.GetAsync("http://localhost:5065/api/Solicitante").Result.Content.ReadAsStringAsync().Result;

                List<Solicitante> solicitante = JsonConvert.DeserializeObject<List<Solicitante>>(json).ToList();

                return View(solicitante);
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Nome")] Solicitante solicitante)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = JsonConvert.SerializeObject(solicitante);
                StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = client.PostAsync("http://localhost:5065/api/Solicitante", body).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = client.GetAsync($"http://localhost:5065/api/Solicitante/id?id={id}").Result.Content.ReadAsStringAsync().Result;

                Solicitante solicitante = JsonConvert.DeserializeObject<Solicitante>(json);

                return View(solicitante);
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = client.GetAsync($"http://localhost:5065/api/Solicitante/id?id={id}").Result.Content.ReadAsStringAsync().Result;

                Solicitante solicitante = JsonConvert.DeserializeObject<Solicitante>(json);

                return View(solicitante);
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Nome")] Solicitante solicitante)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = JsonConvert.SerializeObject(solicitante);
                StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = client.PutAsync($"http://localhost:5065/api/Solicitante/id?id={id}", body).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = client.GetAsync($"http://localhost:5065/api/Solicitante/id?id={id}").Result.Content.ReadAsStringAsync().Result;

                Solicitante solicitante = JsonConvert.DeserializeObject<Solicitante>(json);

                return View(solicitante);
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var resp = client.DeleteAsync($"http://localhost:5065/api/Solicitante/id?id={id}").Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }  
        }
    }
}
