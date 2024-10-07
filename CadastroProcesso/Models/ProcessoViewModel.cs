using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProcessos.Models
{
    public class ProcessoViewModel
    {
        public Guid ProcessoId { get; set; }
        public string? NomeProcesso { get; set; }
        public string? Npu { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVizualizacao { get; set; }
        public string? Uf { get; set; }
        public string? Municipio { get; set; }
        public int? CodIdMunicipio { get; set; }

    }
}