namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public interface IExcluirCadastroUseCase
{
    public Task Execute(long cadastroId);
}
