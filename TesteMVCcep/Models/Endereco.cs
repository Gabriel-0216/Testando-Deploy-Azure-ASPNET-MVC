using System.ComponentModel.DataAnnotations;

namespace TesteMVCcep.Models
{
    public class Endereco
    {
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "É necessário informar o CEP.")]
        public string? CEP { get; set; }
        [Required(ErrorMessage = "É necessário informar a rua.")]
        public string Rua { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessário informar o bairro.")]
        public string Bairro { get; set; } = string.Empty;
        public bool Casa { get; set; }
        public bool Apartamento { get; set; }
        public bool Validado { get; set; } = false;

        public override string ToString()
        {
            return $"CEP: {CEP}, Rua: {Rua}, Bairro: {Bairro}";
        }
    }
}
