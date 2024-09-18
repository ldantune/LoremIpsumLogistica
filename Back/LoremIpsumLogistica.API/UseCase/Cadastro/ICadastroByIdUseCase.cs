using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public interface ICadastroByIdUseCase
{
    public Task<CadastroResponseJson> Execute(long cadastroId);
}
