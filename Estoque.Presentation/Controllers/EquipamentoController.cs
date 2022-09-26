using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Estoque.Presentation.Models;

namespace Estoque.Presentation.Controllers
{
    public class EquipamentoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();
                
                string json = client.GetAsync("http://localhost:5065/api/Equipamento").Result.Content.ReadAsStringAsync().Result;

                List<Equipamento> equipamento = JsonConvert.DeserializeObject<List<Equipamento>>(json).ToList();

                return View(equipamento);
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
            try
            {
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
        public async Task<ActionResult> Create([Bind("Id,Nome,QtdEstoque,QtdTotal,Site")] Equipamento equipamento)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = JsonConvert.SerializeObject(equipamento);
                StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = client.PostAsync("http://localhost:5065/api/Equipamento", body).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = client.GetAsync($"http://localhost:5065/api/Equipamento/id?id={id}").Result.Content.ReadAsStringAsync().Result;

                Equipamento equipamento = JsonConvert.DeserializeObject<Equipamento>(json);

                return View(equipamento);
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = client.GetAsync($"http://localhost:5065/api/Equipamento/id?id={id}").Result.Content.ReadAsStringAsync().Result;

                Equipamento equipamento = JsonConvert.DeserializeObject<Equipamento>(json);

                return View(equipamento);
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Nome,QtdEstoque,QtdTotal,Site")] Equipamento equipamento)
        {
            try
            {
                HttpClient client = new HttpClient();

                string json = JsonConvert.SerializeObject(equipamento);
                StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = client.PutAsync($"http://localhost:5065/api/Equipamento", body).Result;

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

                string json = client.GetAsync($"http://localhost:5065/api/Equipamento/id?id={id}").Result.Content.ReadAsStringAsync().Result;

                Equipamento equipamento = JsonConvert.DeserializeObject<Equipamento>(json);

                return View(equipamento);
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
                var resp = client.DeleteAsync($"http://localhost:5065/api/Equipamento/id?id={id}").Result;

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
