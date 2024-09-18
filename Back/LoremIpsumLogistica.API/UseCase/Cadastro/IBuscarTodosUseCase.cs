using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;


public interface IBuscarTodosUseCase
{
    Task<CadastrosResponseJson> Execute();
}
