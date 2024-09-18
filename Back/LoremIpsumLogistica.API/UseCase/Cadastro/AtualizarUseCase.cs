using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public class AtualizarUseCase : IAtualizarUseCase
{
    private readonly IMapper _mapper;
    private readonly ICadastroRepository _repository;

    public AtualizarUseCase(IMapper mapper, ICadastroRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }

    public async Task Execute(long cadastroId, CadastroRequestJson request)
    {
        Validate(request);

        var cadastro = await _repository.CadastroByIdAtualizacao(cadastroId);

        if (cadastro is null)
            throw new NotFoundException("Cadastro não encontrado para atualização");

        _mapper.Map(request, cadastro);

        _repository.AtualizarCadastro(cadastro);
    }

    private static void Validate(CadastroRequestJson request)
    {
        var result = new CadastroValidacao().Validate(request);

        if (result.IsValid == false)
            throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
    }
}
