using CadastroProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProcessos.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
        }

        public DbSet<ProcessoModel> Processos { get; set; }

    }
}
