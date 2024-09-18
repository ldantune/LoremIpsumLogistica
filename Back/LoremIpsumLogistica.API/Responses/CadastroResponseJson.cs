namespace LoremIpsumLogistica.API.Responses
{
    public class CadastroResponseJson
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string DataNascimento { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
    }
}