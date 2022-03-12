using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteMVCcep.Models;
using TesteMVCcep.Services;

namespace TesteMVCcep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiCepSvc;

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiCepSvc = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Endereco(string? cep)
        {
            if(cep is not null)
            {
                var enderecoModel = await VerificarEnderecoCliente(cep);
                return enderecoModel is null ? View() : View(enderecoModel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Endereco(Endereco model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(model.ToString());
            }
            return RedirectToAction("Index");
        }

        private async Task<Endereco?> VerificarEnderecoCliente(string cep)
        {
            var request = await _apiCepSvc.RequestApiCep(cep);
            if(request is not null)
            {
                return new Endereco()
                {
                    Bairro = request.District,
                    Rua = request.Address,
                    CEP = request.Code,
                };
            }
            return null;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}