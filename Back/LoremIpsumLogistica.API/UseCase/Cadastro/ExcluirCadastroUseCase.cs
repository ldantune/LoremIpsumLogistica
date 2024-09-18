using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Interface;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public class ExcluirCadastroUseCase : IExcluirCadastroUseCase
{
    private readonly IMapper _mapper;
    private readonly ICadastroRepository _repository;

    public ExcluirCadastroUseCase(IMapper mapper, ICadastroRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

    }
    public async Task Execute(long cadastroId)
    {
        var cadastro = await _repository.CadastroById(cadastroId);

         if (cadastro is null)
            throw new NotFoundException("Cadastro não encontrado para excluir");

        await _repository.ExcluirCadastro(cadastroId);
    }
}
