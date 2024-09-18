using AutoMapper;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public class BuscaByIdCadastroUseCase : IBuscaByIdCadastroUseCase
{
    private readonly IMapper _mapper;
    private readonly IEnderecoRepository _repository;

    public BuscaByIdCadastroUseCase(IMapper mapper, IEnderecoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }
    public async Task<EnderecosResponseJson> Execute(long cadastroId)
    {
        var enderecos = await _repository.BuscarTodosByIdCadastro(cadastroId);

        var enderecoResponseJson = _mapper.Map<IList<EnderecoResponseJson>>(enderecos);

        return new EnderecosResponseJson
        {
            Enderecos = enderecoResponseJson
        };
    }
}
