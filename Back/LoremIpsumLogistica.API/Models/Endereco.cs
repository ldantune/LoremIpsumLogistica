using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoremIpsumLogistica.API.Enums;

namespace LoremIpsumLogistica.API.Models;

[Table(name: "Enderecos")]
public class Endereco
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
    public Cadastro? Cadastro { get; set; }
}
