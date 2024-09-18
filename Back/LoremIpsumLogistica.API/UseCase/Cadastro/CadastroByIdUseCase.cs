using AutoMapper;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public class CadastroByIdUseCase : ICadastroByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly ICadastroRepository _repository;

    public CadastroByIdUseCase(IMapper mapper, ICadastroRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }
    public async Task<CadastroResponseJson> Execute(long cadastroId)
    {
        var cadastro = await _repository.CadastroById(cadastroId);

        if(cadastro is null)
            throw new NotFoundException("Cadastro não encontrado");

        return _mapper.Map<CadastroResponseJson>(cadastro);
    }
}
