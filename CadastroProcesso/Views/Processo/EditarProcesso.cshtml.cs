using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CadastroProcesso.Views.Processo
{
    public class EditarProcesso : PageModel
    {
        private readonly ILogger<EditarProcesso> _logger;

        public EditarProcesso(ILogger<EditarProcesso> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}