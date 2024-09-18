using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoremIpsumLogistica.API.Models;

namespace LoremIpsumLogistica.API.Interface;

public interface IEnderecoRepository
{
    public Task<IList<Endereco>> BuscarTodosByIdCadastro(long cadastroId);
    public Task<Endereco?> EnderecoById(long enderecoId);
    public Task<Endereco?> EnderecoByIdAtualizacao(long enderecoId);
    public Task SalvarEndereco(Endereco endereco);
    public void AtualizarEndereco(Endereco endereco);
    public Task ExcluirEndereco(long enderecoId);
}
