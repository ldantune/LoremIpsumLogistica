using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public interface IEnderecoByIdUseCase
{
    public Task<EnderecoResponseJson> Execute(long enderecoId);
}

