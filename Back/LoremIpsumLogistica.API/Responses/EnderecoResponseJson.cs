using LoremIpsumLogistica.API.Enums;

namespace LoremIpsumLogistica.API.Responses;

public class EnderecoResponseJson
{
    public long Id { get; set; }
    public string CEP { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public TipoEndereco Tipo { get; set; }
    public long CadastroId { get; set; }
}
