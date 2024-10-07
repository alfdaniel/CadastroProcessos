using CadastroProcesso.Models;
using CadastroProcesso.Services.IBGE;
using CadastroProcessos.Models;
using CadastroProcessos.Services.Processo;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProcessos.Controllers
{

    public class ProcessoController : Controller
    {
        private readonly IProcessoService _processoService;
        private readonly IIbgeService _ibgeService;
        // private readonly AppDbContext _context;

        public ProcessoController(IProcessoService processoService, IIbgeService ibgeService)
        {
            // _context = context;
            _processoService = processoService;
            _ibgeService = ibgeService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProcessoModel> processos = await _processoService.ObterTodosProcessos();
            return View(processos);
        }

        [HttpGet]
        public async Task<IActionResult> CadastroProcesso()
        {
            var estados = await ObterEstados();
            ViewData["Estados"] = estados;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastroProcesso(ProcessoModel processoModel)
        {

            if (processoModel.Npu != null)
            {
                processoModel.Npu = processoModel.Npu.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");
            }

            if (!ModelState.IsValid)
            {
                var estados = await ObterEstados();
                ViewData["Estados"] = estados;
                return View(processoModel);
            }
            await _processoService.AdicionarProcesso(processoModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DetalharProcesso(Guid? processoId)
        {
            if (processoId == null)
            {
                return RedirectToAction("Index");
            }
            var processo = await _processoService.ObterProcessoId(processoId.Value);

            if (processo == null)
            {
                return View("Index");
            }
            return View(processo);
        }

        [HttpGet]
        public async Task<IActionResult> EditarProcesso(Guid processoId)
        {
            var processo = await _processoService.ObterProcessoId(processoId);
            if (processo == null)
            {
                return View("Index");
            }
            return View(processo);
        }

        [HttpPut("Processo/EditarProcesso")]
        public async Task<IActionResult> EditarProcesso(ProcessoModel processoModel)
        {
            if (!ModelState.IsValid)
            {
                return View(processoModel);
            }
            await _processoService.AtualizarProcesso(processoModel);
            return RedirectToAction("Index");
        }

        [HttpDelete("Processo/ExcluirProcesso/{processoId}")]
        public async Task<IActionResult> ExcluirProcesso(Guid processoId)
        {
            var processo = await _processoService.ObterProcessoId(processoId);
            if (processo == null)
            {
                return RedirectToAction("Index");
            }
            await _processoService.ExcluirProcesso(processoId);
            return RedirectToAction("Index");

        }

        [HttpPut("Processo/ConfirmaVizualizacao/{processoId}")]
        public async Task<IActionResult> ConfirmaVizualizacao(Guid processoId)
        {
            await _processoService.ConfirmaVisualizacao(processoId);
            return Ok();
        }

        [HttpGet("Estados")]
        public async Task<IEnumerable<UfModel>> ObterEstados()
        {
            var estados = await _ibgeService.BuscaUfs();
            return estados;
        }

        [HttpGet("Processo/ObterMunicipios/{uf}")]
        public async Task<IActionResult> ObterMunicipios(string uf)
        {
            var municipios = await _ibgeService.BuscaMunicipiosUf(uf);
            return Json(municipios);
        }
    }
}
