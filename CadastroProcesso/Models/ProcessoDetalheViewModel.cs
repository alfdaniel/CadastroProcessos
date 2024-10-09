
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CadastroProcesso.Models.Mask;
namespace CadastroProcessos.Models
{
    [AutoMap(typeof(ProcessoModel))]
    public class ProcessoDetalheViewModel
    {
        public Guid ProcessoId { get; set; }
        public string? NomeProcesso { get; set; }
        public string? Npu { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVizualizacao { get; set; }
        public string? Uf { get; set; }
        public string? Municipio { get; set; }
        public int? CodMunicipio { get; set; }
        [SourceMember(nameof(ProcessoModel.Npu))]
        [ValueConverter(typeof(NpuMask))]
        public string? NpuFormatado { get; set; }
        public bool Visualizado { get; set; }

    }
}