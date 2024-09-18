using AutoMapper;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public class EnderecoByIdUseCase : IEnderecoByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IEnderecoRepository _repository;

    public EnderecoByIdUseCase(IMapper mapper, IEnderecoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }
    public async Task<EnderecoResponseJson> Execute(long enderecoId)
    {
        var endereco = await _repository.EnderecoById(enderecoId);

        if (endereco is null)
            throw new NotFoundException("Endereço não encontrado");

        return _mapper.Map<EnderecoResponseJson>(endereco);
    }
}
