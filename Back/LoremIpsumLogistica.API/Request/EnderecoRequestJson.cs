using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoremIpsumLogistica.API.Enums;

namespace LoremIpsumLogistica.API.Request;

public class EnderecoRequestJson
{
    public string CEP { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string Cidade { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public TipoEndereco Tipo { get; set; }
    public long CadastroId { get; set; }
}
