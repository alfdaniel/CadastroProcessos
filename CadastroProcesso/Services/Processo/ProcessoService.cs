using System.Text.RegularExpressions;
using AutoMapper;
using CadastroProcesso.Services.Mensagens;
using CadastroProcessos.Models;
using CadastroProcessos.Repository;


namespace CadastroProcessos.Services.Processo
{
    public class ProcessoService : IProcessoService
    {
        private readonly IProcessoRepository _processoRepository;

        private readonly IMapper _mapper;

        public ProcessoService(IProcessoRepository processoRepository, IMapper mapper)
        {
            _processoRepository = processoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProcessoListViewModel>> ObterTodosProcessos()
        {
            var result = await _processoRepository.ObterTodosProcessos();
            return _mapper.Map<IEnumerable<ProcessoListViewModel>>(result);
        }

        public async Task<Guid> AdicionarProcesso(ProcessoModel processo)
        {

            ProcessoModel processoModel;

            processo.Npu = Regex.Replace(processo.Npu, @"\D", "");

            var id = Guid.NewGuid();

            processoModel = new ProcessoModel
            {
                ProcessoId = id,
                NomeProcesso = processo.NomeProcesso,
                Npu = processo.Npu,
                Uf = processo.Uf,
                Municipio = processo.Municipio,
                CodMunicipio = processo.CodMunicipio,
                DataCadastro = DateTime.Now,
                Visualizado = false
            };

            await _processoRepository.AdicionarProcesso(processoModel);
            return id;

        }

        public async Task<ProcessoDetalheViewModel> ObterProcessoId(Guid processoId)
        {

            var processo = await _processoRepository.ObterProcessoId(processoId);
            return _mapper.Map<ProcessoDetalheViewModel>(processo);
        }

        public async Task AtualizarProcesso(ProcessoModel processoModel)
        {

            var processo = await _processoRepository.ObterProcessoId(processoModel.ProcessoId) ?? throw new Exception(ProcessoMSG.ProcessoNaoEncotrado);

            processo.NomeProcesso = processoModel.NomeProcesso;
            processo.Npu = processoModel.Npu;
            processo.Uf = processoModel.Uf;
            processo.Municipio = processoModel.Municipio;
            processo.CodMunicipio = processoModel.CodMunicipio;

            await _processoRepository.AtualizarProcesso(processo);
        }

        public async Task ExcluirProcesso(Guid processoId)
        {

            await _processoRepository.RemoverProcesso(processoId);

        }

        public async Task ConfirmaVisualizacao(Guid processoId)
        {

            var processo = await _processoRepository.ObterProcessoId(processoId)
                           ?? throw new Exception(ProcessoMSG.ProcessoNaoEncotrado);

            if (!processo.Visualizado)
            {
                processo.DataVizualizacao = DateTime.Now;
                processo.Visualizado = true;
                await _processoRepository.AtualizarProcesso(processo);
            }
            return;

        }

    }

}