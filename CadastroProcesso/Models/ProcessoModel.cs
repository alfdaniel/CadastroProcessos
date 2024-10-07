using System.ComponentModel.DataAnnotations;

namespace CadastroProcessos.Models
{
    public class ProcessoModel
    {
        [Key]
        public Guid ProcessoId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? NomeProcesso { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Npu { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataVizualizacao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Uf { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Municipio { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int? CodMunicipio { get; set; }
        public bool Visualizado { get; set; }

    }
}
