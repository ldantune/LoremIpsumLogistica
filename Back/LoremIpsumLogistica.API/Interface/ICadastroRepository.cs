using LoremIpsumLogistica.API.Models;

namespace LoremIpsumLogistica.API.Interface;

public interface ICadastroRepository
{
    public Task<Models.Cadastro?> CadastroById(long cadastroId);
    public Task<Models.Cadastro?> CadastroByIdAtualizacao(long recipeId);
    public Task<IList<Models.Cadastro>> BuscarTodos();
    public Task SalvarCadastro(Cadastro cadastro);
    public void AtualizarCadastro(Models.Cadastro cadastro);
    public Task ExcluirCadastro(long cadastroId);
}
