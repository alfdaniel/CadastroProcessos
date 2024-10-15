using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CadastroProcessos.Models
{

    public class ProcessoModel
    {
        [Key]
        public Guid ProcessoId { get; set; }
        [Required(ErrorMessage = "O nome do Processo é Obrigatório"), MaxLength(120)]
        public string? NomeProcesso { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [CustomValidation(typeof(ProcessoModel), nameof(ValidateNpu))]
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

        public static ValidationResult ValidateNpu(string? npu, ValidationContext context)
        {
            if (string.IsNullOrEmpty(npu))
            {
                return new ValidationResult("NPU não pode ser nulo ou vazio.");
            }

            // Remove caracteres não numéricos
            npu = Regex.Replace(npu, @"\D", "");

            if (npu.Length != 20)
            {
                return new ValidationResult("NPU deve conter exatamente 20 caracteres.");
            }

            return ValidationResult.Success!;
        }

    }
}
