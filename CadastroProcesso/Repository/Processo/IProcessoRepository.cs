
using CadastroProcessos.Models;

namespace CadastroProcessos.Repository
{
    public interface IProcessoRepository
    {
        Task<IEnumerable<ProcessoModel>> ObterTodosProcessos();
        Task<ProcessoModel> ObterProcessoId(Guid processoId);
        Task AdicionarProcesso(ProcessoModel processoModel);
        Task AtualizarProcesso(ProcessoModel processo);
        Task RemoverProcesso(Guid processoId);
        Task ConfirmaVisualizacao(Guid processoId);

    }
}
