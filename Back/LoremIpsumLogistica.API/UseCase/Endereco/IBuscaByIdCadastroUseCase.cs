using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public interface IBuscaByIdCadastroUseCase
{
    Task<IList<EnderecoResponseJson>> Execute(long cadastroId);
}
