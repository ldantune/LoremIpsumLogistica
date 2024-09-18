using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoremIpsumLogistica.API.Models;

[Table(name: "Cadastros")]
public class Cadastro
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string DataNascimento { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public IList<Endereco> Enderecos { get; set; } = [];

}
