using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public interface ISalvarCadastroUseCase
{
    public Task<Models.Cadastro> Execute(CadastroRequestJson request);
}
