using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoremIpsumLogistica.API.Converters;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public class SalvarCadastroUseCase : ISalvarCadastroUseCase
{
    private readonly ICadastroRepository _repository;
    private readonly DateTimeConverter _dateTimeConverter;
    private readonly IMapper _mapper;

    public SalvarCadastroUseCase(ICadastroRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _dateTimeConverter = new DateTimeConverter();
    }
    public async Task<Models.Cadastro> Execute(CadastroRequestJson request)
    {
        Validacao(request);

        var cadastro = _mapper.Map<Models.Cadastro>(request);

        cadastro.DataNascimento = _dateTimeConverter.ParseDate(cadastro.DataNascimento).ToString();

        await _repository.SalvarCadastro(cadastro);

        return cadastro;
    }

    private static void Validacao(CadastroRequestJson request)
    {
        var resultado = new CadastroValidacao().Validate(request);

        if (resultado.IsValid == false)
        {
            throw new ErrorOnValidationException(resultado.Errors.Select(e => e.ErrorMessage).Distinct().ToList());
        }
    }
}
