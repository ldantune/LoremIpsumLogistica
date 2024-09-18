using AutoMapper;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public class AtualizarEnderecoUseCase : IAtualizarEnderecoUseCase
{
    private readonly IMapper _mapper;
    private readonly IEnderecoRepository _repository;

    public AtualizarEnderecoUseCase(IMapper mapper, IEnderecoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }
    public async Task Execute(long enderecoId, EnderecoRequestJson request)
    {
        Validate(request);

        var endereco = await _repository.EnderecoByIdAtualizacao(enderecoId);

        if(endereco is null)
            throw new NotFoundException("Endereço não encontrado para atualização");
        
        if(request.CadastroId != endereco.CadastroId)
            throw new NotFoundException("Na atualização do endereço o CadastroId não pode ser alterado");

        _mapper.Map(request, endereco);

        _repository.AtualizarEndereco(endereco);
    }

    private static void Validate(EnderecoRequestJson request)
    {
        var result = new EnderecoValidacao().Validate(request);

        if (result.IsValid == false)
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
    }
}
