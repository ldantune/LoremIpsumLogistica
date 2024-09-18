using AutoMapper;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Request;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public class SalvarEnderecoUseCase : ISalvarEnderecoUseCase
{
    private readonly IEnderecoRepository _repository;
    private readonly ICadastroRepository _cadastroRepository;
    private readonly IMapper _mapper;

    public SalvarEnderecoUseCase(IEnderecoRepository repository, ICadastroRepository cadastroRepository, IMapper mapper)
    {
        _repository = repository;
        _cadastroRepository = cadastroRepository;
        _mapper = mapper;
    }

    public async Task<EnderecoResponseJson> Execute(EnderecoRequestJson request)
    {
        Validacao(request);

        var cadastro = await _cadastroRepository.CadastroById(request.CadastroId);

        if(cadastro is null)    
            throw new NotFoundException("O Id Cadastro informado é inválido");

        var endereco = _mapper.Map<Models.Endereco>(request);

        await _repository.SalvarEndereco(endereco);

        return _mapper.Map<EnderecoResponseJson>(endereco);
    }

    private static void Validacao(EnderecoRequestJson request)
    {
        var resultado = new EnderecoValidacao().Validate(request);

        if (resultado.IsValid == false)
        {
            throw new ErrorOnValidationException(resultado.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
        }
    }
}
