using TesteMVCcep.Services.ResponseDto;

namespace TesteMVCcep.Services
{
    public interface IApiService
    {
        Task<CepResponseDto?> RequestApiCep(string cep);
    }
}
