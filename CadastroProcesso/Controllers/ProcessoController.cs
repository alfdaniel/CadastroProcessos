using CadastroProcesso.Models;
using CadastroProcesso.Services.IBGE;
using CadastroProcesso.Services.Mensagens;
using CadastroProcessos.Models;
using CadastroProcessos.Services.Processo;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProcessos.Controllers
{

    public class ProcessoController : Controller
    {
        private readonly IProcessoService _processoService;
        private readonly IIbgeService _ibgeService;

        public ProcessoController(IProcessoService processoService, IIbgeService ibgeService)
        {
            _processoService = processoService;
            _ibgeService = ibgeService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var processos = await _processoService.ObterTodosProcessos();

                if (processos == null || !processos.Any())
                {
                    TempData["Mensagem"] = ProcessoMSG.ErroBuscarProcessos;
                    return View(new List<ProcessoListViewModel>());
                }
                return View(processos);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ProcessoMSG.ErroBuscarProcessos;
                return View(new List<ProcessoListViewModel>());
            }
        }



        [HttpGet]
        public async Task<IActionResult> CadastroProcesso()
        {
            var estados = await ObterEstados();
            ViewData["Estados"] = estados;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroProcesso(ProcessoModel processoModel)
        {

            if (!ModelState.IsValid)
            {
                var estados = await ObterEstados();
                ViewData["Estados"] = estados;
                return View(processoModel);
            }

            await _processoService.AdicionarProcesso(processoModel);

            TempData["Mensagem"] = ProcessoMSG.ProcessoAdicionadoSucesso;

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
        public async Task<IActionResult> AtualizarProcesso(Guid processoId)
        {
            var processo = await _processoService.ObterProcessoId(processoId);
            var estados = await ObterEstados();
            ViewData["Estados"] = estados;
            return View(processo);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarProcesso(ProcessoModel processoModel)
        {
            if (ModelState.IsValid)
            {
                await _processoService.AtualizarProcesso(processoModel);
                TempData["Mensagem"] = ProcessoMSG.ProcessoAtualizadoSucesso;
                return RedirectToAction("Index");
            }

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
            TempData["Mensagem"] = "Processo visualizado com sucesso!";
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
            return Ok(municipios);
        }
    }
}
