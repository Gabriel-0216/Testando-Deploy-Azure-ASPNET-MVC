using System.ComponentModel.DataAnnotations;

namespace TesteMVCcep.Models
{
    public class Endereco
    {
        [DataType(DataType.PostalCode)]
        public string? CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public bool Casa { get; set; }
        public bool Apartamento { get; set; }
        public bool Validado { get; set; } = false;

        public override string ToString()
        {
            return $"CEP: {CEP}, Rua: {Rua}, Bairro: {Bairro}";
        }
    }
}
