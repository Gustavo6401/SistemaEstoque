using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;

namespace Estoque.Presentation.Controllers
{
    public class MaquinaSolicitadaController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                return RedirectToAction("Index", "Solicitacao");
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
        public IActionResult Create([Bind("Id,QtdSolicitada,SolicitanteId,EquipamentoId")] Models.MaquinaSolicitada maquinaSolicitada, string nomeEquipamento, string nomeSolicitante)
        {
            try
            {
                HttpClient client = new HttpClient();

                string jsonEquipamento = client.GetAsync($"http://localhost:5065/api/Equipamento/nome?nome={nomeEquipamento}").Result.Content.ReadAsStringAsync().Result;

                Models.Equipamento equipamento = JsonConvert.DeserializeObject<Models.Equipamento>(jsonEquipamento);
                maquinaSolicitada.EquipamentoId = equipamento.Id;
                maquinaSolicitada.Equipamento = equipamento;

                string jsonSolicitante = client.GetAsync($"http://localhost:5065/api/Solicitante/nome?name={nomeSolicitante}").Result.Content.ReadAsStringAsync().Result;

                Models.Solicitante solicitante = JsonConvert.DeserializeObject<Models.Solicitante>(jsonSolicitante);
                maquinaSolicitada.SolicitanteId = solicitante.Id;
                maquinaSolicitada.Solicitante = solicitante;

                string json = JsonConvert.SerializeObject(maquinaSolicitada);
                StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = client.PostAsync("http://localhost:5065/api/MaquinaSolicitada", body).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Erro = "Ocorreu um Erro, contate o Administrador do Sistema!";

                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id, string nomeEquipamento, string nomeSolicitante)
        {
            MaquinaSolicitadaRepository repository = new MaquinaSolicitadaRepository();
            var maquinaSolicitada = repository.GetMaquinaSolicitada(id);

            EquipamentoRepository equipamentoRepository = new EquipamentoRepository();
            var equipamento = equipamentoRepository.GetById(maquinaSolicitada.EquipamentoId);
            nomeEquipamento = equipamento.Nome;

            SolicitanteRepository solicitanteRepository = new SolicitanteRepository();
            var solicitante = solicitanteRepository.GetById(maquinaSolicitada.SolicitanteId);
            nomeSolicitante = solicitante.Nome;

            return View(maquinaSolicitada);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,QtdSolicitada,SolicitanteId,EquipamentoId")] MaquinaSolicitada maquinaSolicitada, string nomeEquipamento, string nomeSolicitante)
        {
            EquipamentoRepository equipamentoRepository = new EquipamentoRepository();
            Equipamento equipamento = equipamentoRepository.ProcurarPorNome(nomeEquipamento);
            maquinaSolicitada.EquipamentoId = equipamento.Id;

            SolicitanteRepository solicitanteRepository = new SolicitanteRepository();
            Solicitante solicitante = solicitanteRepository.ProcurarPorNome(nomeSolicitante);
            maquinaSolicitada.SolicitanteId = solicitante.Id;

            MaquinaSolicitadaRepository repository = new MaquinaSolicitadaRepository();
            repository.Update(maquinaSolicitada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            MaquinaSolicitadaRepository repository = new MaquinaSolicitadaRepository();
            var maquinaSolicitada = repository.GetMaquinaSolicitada(id);

            return View(maquinaSolicitada);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            MaquinaSolicitadaRepository repository = new MaquinaSolicitadaRepository();
            var maquinaSolicitada = repository.GetMaquinaSolicitada(id);

            if(maquinaSolicitada != null)
            {
                repository.Delete(maquinaSolicitada);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
