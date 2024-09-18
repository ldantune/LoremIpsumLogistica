
using AutoMapper;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public class ExcluirEnderecoUseCase : IExcluirEnderecoUseCase
{
    private readonly IMapper _mapper;
    private readonly IEnderecoRepository _repository;

    public ExcluirEnderecoUseCase(IMapper mapper, IEnderecoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }
    public async Task Execute(long enderecoId)
    {
        var endereco = await _repository.EnderecoById(enderecoId);

        if(endereco is null)
            throw new NotFoundException("Endereço não encontrado para excluir");

        await _repository.ExcluirEndereco(enderecoId);
    }
}
