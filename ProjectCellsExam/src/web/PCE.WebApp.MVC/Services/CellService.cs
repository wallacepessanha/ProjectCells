using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;
using PCE.WebApp.MVC.Extensions;
using System.Net;
using PCE.WebApp.MVC.Models;
using PCE.WebApp.MVC.Services.Contracts;

namespace PCE.WebApp.MVC.Services
{
    public class CellService : ICellService
    {
        private readonly HttpClient _httpClient;

        public CellService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CellUrl);
        }

        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        }

        public async Task<CellViewModel?> FindById(int Id)
        {
            var response = await _httpClient.GetAsync($"/api/cells/find-by-id/{Id}");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;            

            return await DeserializarObjetoResponse<CellViewModel>(response);
        }

        public async Task<IEnumerable<CellViewModel>>? FindAll()
        {
            var response = await _httpClient.GetAsync($"/api/cells/find-all");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            return await DeserializarObjetoResponse<IEnumerable<CellViewModel>>(response);
        }

        public async Task InsertCell(CellViewModel cellViewModel)
        {
            var cellContent = ObterConteudo(cellViewModel);

            await _httpClient.PostAsync("/api/cells/", cellContent);
        }

        public async Task UpdateCell(int id, CellViewModel cellViewModel)
        {
            var cellContent = ObterConteudo(cellViewModel);

            await _httpClient.PutAsync($"/api/cells/update-cell/{id}", cellContent);
        }

        public async Task DeleteCell(int id)
        {
            await _httpClient.DeleteAsync($"/api/cells/delete-cell/{id}");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }
    }
}
