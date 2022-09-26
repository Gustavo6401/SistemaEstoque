using Microsoft.AspNetCore.Mvc;
using Estoque.Domain.Entities;
using Estoque.Infra.Repositories;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : Controller
    {
        [HttpGet]
        public async Task<IAsyncEnumerable<Equipamento>> GetEquipamento()
        {
            EquipamentoRepository repository = new EquipamentoRepository();
            return repository.Get();
        }

        [HttpGet("id")]
        public async Task<Equipamento> GetEquipamentoById(int id)
        {
            EquipamentoRepository repository = new EquipamentoRepository();
            return repository.GetById(id);
        }

        [HttpGet("nome")]
        public async Task<Equipamento> GetEquipamentoByNome(string nome)
        {
            EquipamentoRepository repository = new EquipamentoRepository();
            return repository.ProcurarPorNome(nome);
        }

        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEquipamento(Equipamento equipamento)
        {
            // Essa parte ficou foda!
            EquipamentoRepository repository = new EquipamentoRepository();
            repository.Add(equipamento);

            return CreatedAtAction("GetEquipamento", new { id = equipamento.Id }, equipamento);
        }

        [HttpPut]
        public async Task<IActionResult> PutEquipamento(Equipamento equipamento)
        {
            EquipamentoRepository repository = new EquipamentoRepository();

            Equipamento equ = repository.GetById(equipamento.Id);
            equ.Nome = equipamento.Nome;
            equ.QtdEstoque = equipamento.QtdEstoque;
            equ.QtdTotal = equipamento.QtdTotal;
            equ.Site = equipamento.Site;

            repository.Update(equ);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteEquipamento(int id)
        {
            EquipamentoRepository repository = new EquipamentoRepository();
            var equipamento = repository.GetById(id);

            repository.Delete(equipamento);

            return NoContent();
        }
    }
}
