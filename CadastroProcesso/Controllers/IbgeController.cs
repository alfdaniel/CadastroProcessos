
using CadastroProcesso.Services.IBGE;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProcesso.Controllers
{
    public class IbgeController : Controller
    {
        private readonly ILogger<IbgeController> _logger;

        private readonly IIbgeService _ibgeService;

        public IbgeController(ILogger<IbgeController> logger, IIbgeService ibgeService)
        {
            _logger = logger;
            _ibgeService = ibgeService;
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        // [HttpGet("Estados")]
        public async Task<IActionResult> ObterEstados()
        {
            var estados = await _ibgeService.BuscaUfs();
            return Ok(estados);
        }

        // [HttpGet("Municipios")]
        public async Task<IActionResult> ObterMunicipios(string uf)
        {
            var municipios = await _ibgeService.BuscaMunicipiosUf(uf);
            return Json(municipios);
        }

    }
}