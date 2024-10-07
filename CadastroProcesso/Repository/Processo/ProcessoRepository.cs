
using CadastroProcessos.Data;
using CadastroProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProcessos.Repository
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly AppDbContext _context;

        public ProcessoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProcessoModel>> ObterTodosProcessos()
        {
            return await _context.Processos.ToListAsync();
        }

        public async Task<ProcessoModel> ObterProcessoId(Guid processoId)
        {
            return await _context.Processos.FindAsync(processoId);
        }

        public async Task AdicionarProcesso(ProcessoModel processo)
        {
            await _context.Processos.AddAsync(processo);
            _context.SaveChanges();
        }

        public async Task AtualizarProcesso(ProcessoModel processo)
        {
            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverProcesso(Guid id)
        {
            var processo = await ObterProcessoId(id);
            if (processo != null)
            {
                _context.Processos.Remove(processo);
                await _context.SaveChangesAsync();
            }
        }
        public async Task ConfirmaVisualizacao(Guid processoId)
        {
            var processo = await ObterProcessoId(processoId);
            if (processo != null)
            {
                await AtualizarProcesso(processo);
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
