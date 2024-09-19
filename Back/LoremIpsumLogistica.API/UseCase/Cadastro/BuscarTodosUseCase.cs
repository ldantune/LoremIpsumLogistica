using AutoMapper;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public class BuscarTodosUseCase : IBuscarTodosUseCase
{
    private readonly IMapper _mapper;
    private readonly ICadastroRepository _repository;

    public BuscarTodosUseCase(IMapper mapper, ICadastroRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }
    public async Task<IList<CadastroResponseJson>> Execute()
    {
        var cadastros = await _repository.BuscarTodos();

        var cadastroResponseJson = _mapper.Map<IList<CadastroResponseJson>>(cadastros);

        return cadastroResponseJson;
    }
}
