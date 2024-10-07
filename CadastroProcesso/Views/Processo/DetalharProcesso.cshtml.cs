using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CadastroProcesso.Views.Processo
{
    public class DetalharProcesso : PageModel
    {
        private readonly ILogger<DetalharProcesso> _logger;

        public DetalharProcesso(ILogger<DetalharProcesso> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}