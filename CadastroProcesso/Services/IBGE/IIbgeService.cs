
using CadastroProcesso.Models;

namespace CadastroProcesso.Services.IBGE
{
   public interface IIbgeService
{
    Task<IEnumerable<UfModel>> BuscaUfs();
    Task<IEnumerable<MunicipioModel>> BuscaMunicipiosUf(string uf);
}

}