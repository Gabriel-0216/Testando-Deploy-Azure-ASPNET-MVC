namespace TesteMVCcep.Services.ResponseDto
{
    public class CepResponseDto
    {
        public int Status { get; set; }
        public bool Ok { get; set; }
        public string Code { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
