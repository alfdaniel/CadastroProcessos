using CadastroProcessos.Models;
using CadastroProcessos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProcessos.Services.Processo
{
    public class ProcessoService : IProcessoService
    {
        private readonly IProcessoRepository _processoRepository;

        public ProcessoService(IProcessoRepository processoRepository)
        {
            _processoRepository = processoRepository;
        }

        public async Task<IEnumerable<ProcessoModel>> ObterTodosProcessos()
        {
            var result = await _processoRepository.ObterTodosProcessos();
            return result;
        }


        public async Task<Guid> AdicionarProcesso(ProcessoModel processo)
        {
            try
            {
                ProcessoModel processoModel;

                var id = Guid.NewGuid();

                processoModel = new ProcessoModel
                {
                    ProcessoId = id,
                    NomeProcesso = processo.NomeProcesso,
                    Npu = processo.Npu != null ? processo.Npu.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "") : string.Empty,
                    Uf = processo.Uf,
                    Municipio = processo.Municipio,
                    CodMunicipio = processo.CodMunicipio,
                    Visualizado = false
                };

                await _processoRepository.AdicionarProcesso(processoModel);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar Processo: {ex.Message}", ex);
            }
        }

        public Task<ProcessoModel> ObterProcessoId(Guid processoId)
        {
            try
            {
                var processo = _processoRepository.ObterProcessoId(processoId);
                return processo;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao buscar Processo: {ex.Message}", ex);
            }
        }

        public async Task AtualizarProcesso(ProcessoModel processoModel)
        {
            try
            {
                var processo = await _processoRepository.ObterProcessoId(processoModel.ProcessoId) ?? throw new Exception("Processo não encontrado");
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
                var processo = await _processoRepository.ObterProcessoId(processoId) ?? throw new Exception("Processo não encontrado");
                await _processoRepository.RemoverProcesso(processoId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir Processo: {ex.Message}", ex);
            }
        }

        public async Task ConfirmaVisualizacao(Guid processoId)
        {
            try
            {
                var processo = await _processoRepository.ObterProcessoId(processoId)
                               ?? throw new Exception("Processo não encontrado");

                if (!processo.Visualizado) // Corrigido de "Vizualizado" para "Visualizado"
                {
                    processo.Visualizado = true;
                    await _processoRepository.AtualizarProcesso(processo);
                }
                else
                {
                    throw new Exception("Processo já foi visualizado anteriormente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao confirmar visualização do Processo: {ex.Message}", ex);
            }
        }

    }

}