using CadastroProcessos.Models;

namespace CadastroProcessos.Services.Processo
{
    public interface IProcessoService
    {
        Task<IEnumerable<ProcessoListViewModel>> ObterTodosProcessos();
        Task<ProcessoDetalheViewModel> ObterProcessoId(Guid processoId);
        Task<Guid> AdicionarProcesso(ProcessoModel processoModel);
        Task AtualizarProcesso(ProcessoModel processoModel);
        Task ExcluirProcesso(Guid processoId);
        Task ConfirmaVisualizacao(Guid processoId);

    }

}