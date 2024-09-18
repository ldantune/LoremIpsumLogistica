using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public interface IAtualizarEnderecoUseCase
{
    Task Execute(long enderecoId, EnderecoRequestJson request);
}
