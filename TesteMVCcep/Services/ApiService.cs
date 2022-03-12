using System.Text.Json;
using TesteMVCcep.Services.ResponseDto;

namespace TesteMVCcep.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        public ApiService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _configuration = config;
        }
        public async Task<CepResponseDto?> RequestApiCep(string cep)
        {
            var client = GetClient();
            var url = $"https://ws.apicep.com/cep.json?code={cep}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var deserialize = await
                    JsonSerializer.DeserializeAsync<CepResponseDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                return deserialize;
            }
            return null;
        }
        private HttpClient GetClient() => _clientFactory.CreateClient();
    }
}
