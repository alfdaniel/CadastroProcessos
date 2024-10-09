using System.ComponentModel.DataAnnotations;

namespace CadastroProcessos.Models
{

    public class ProcessoModel
    {
        [Key]
        public Guid ProcessoId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório"), MaxLength(120)]
        public string? NomeProcesso { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [MinLength(20, ErrorMessage = "O NPU deve ter no mínimo 20 caracteres.")]
        [MaxLength(20, ErrorMessage = "O NPU deve ter no máximo 20 caracteres.")]
        public string? Npu { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataCadastro { get; set; }
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
