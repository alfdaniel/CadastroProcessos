
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CadastroProcesso.Models.Mask;
namespace CadastroProcessos.Models
{
    [AutoMap(typeof(ProcessoModel))]
    public class ProcessoListViewModel
    {
        public Guid ProcessoId { get; set; }
        public string? Npu { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? Uf { get; set; }
        [SourceMember(nameof(ProcessoModel.Npu))]
        [ValueConverter(typeof(NpuMask))]
        public string? NpuFormatado { get; set; }

    }
}