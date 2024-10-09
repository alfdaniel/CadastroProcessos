using System.Text.RegularExpressions;
using AutoMapper;
using CadastroProcesso.Services.Mensagens;
using CadastroProcessos.Models;
using CadastroProcessos.Repository;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var result = await _processoRepository.ObterTodosProcessos();
                return _mapper.Map<IEnumerable<ProcessoListViewModel>>(result);

            }
            catch (Exception)
            {
                // throw new Exception(ProcessoMSG.ErroBuscarProcessos);
                throw new Exception("Erro ao buscar processos");
            }
        }

        public async Task<Guid> AdicionarProcesso(ProcessoModel processo)
        {
            try
            {
                ProcessoModel processoModel;

                if (processo.Npu == null)
                {
                    throw new Exception("NPU não pode ser nulo.");
                }

                processo.Npu = Regex.Replace(processo.Npu, @"\D", "");

                if (processo.Npu.Length < 20)
                {
                    throw new Exception("NPU deve conter 20 caracteres.");
                }

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
            catch (Exception)
            {
                throw new Exception(ProcessoMSG.ErroAdicionarProcesso);
            }
        }

        public async Task<ProcessoDetalheViewModel> ObterProcessoId(Guid processoId)
        {
            try
            {
                var processo = await _processoRepository.ObterProcessoId(processoId);
                return _mapper.Map<ProcessoDetalheViewModel>(processo);
            }
            catch (Exception)
            {
                throw new Exception(ProcessoMSG.ErroBuscarProcessoId);
            }
        }

        public async Task AtualizarProcesso(ProcessoModel processoModel)
        {
            try
            {
                var processo = await _processoRepository.ObterProcessoId(processoModel.ProcessoId) ?? throw new Exception(ProcessoMSG.ProcessoNaoEncotrado);

                processo.NomeProcesso = processoModel.NomeProcesso;
                processo.Npu = processoModel.Npu;
                processo.Uf = processoModel.Uf;
                processo.Municipio = processoModel.Municipio;
                processo.CodMunicipio = processoModel.CodMunicipio;

                await _processoRepository.AtualizarProcesso(processo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar Processo: {ex.Message}", ex);
            }
        }

        public async Task ExcluirProcesso(Guid processoId)
        {
            try
            {
                var processo = await _processoRepository.ObterProcessoId(processoId) ?? throw new Exception(ProcessoMSG.ProcessoNaoEncotrado);
                await _processoRepository.RemoverProcesso(processoId);
            }
            catch (Exception)
            {
                throw new Exception(ProcessoMSG.ErroExcluirProcesso);
            }
        }

        public async Task ConfirmaVisualizacao(Guid processoId)
        {
            try
            {
                var processo = await _processoRepository.ObterProcessoId(processoId)
                               ?? throw new Exception(ProcessoMSG.ProcessoNaoEncotrado);

                if (!processo.Visualizado)
                {
                    processo.DataVizualizacao = DateTime.Now;
                    processo.Visualizado = true;
                    await _processoRepository.AtualizarProcesso(processo);
                }
                else
                {
                    throw new Exception(ProcessoMSG.ProcessoJaVisualizado);
                }
            }
            catch (Exception)
            {
                throw new Exception(ProcessoMSG.ErroConfirmaVisualizacao);
            }
        }

    }

}