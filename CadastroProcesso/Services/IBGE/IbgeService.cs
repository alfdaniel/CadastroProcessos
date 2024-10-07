using System.Text.Json;
using CadastroProcesso.Models;

namespace CadastroProcesso.Services.IBGE
{
    public class IbgeService : IIbgeService
    {
        private readonly HttpClient _httpClient;

        public IbgeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UfModel>> BuscaUfs()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new List<UfModel>(JsonSerializer.Deserialize<IEnumerable<UfModel>>(content));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar UFs: {ex.Message}", ex);
            }
            return new List<UfModel>();
        }

        public async Task<IEnumerable<MunicipioModel>> BuscaMunicipiosUf(string uf)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/municipios");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new List<MunicipioModel>(JsonSerializer.Deserialize<IEnumerable<MunicipioModel>>(content));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar Municipios: {ex.Message}", ex);
            }
            return new List<MunicipioModel>();
        }
    }

}