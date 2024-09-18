using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoremIpsumLogistica.API.Request;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public interface ISalvarEnderecoUseCase
{
    public Task<EnderecoResponseJson> Execute(EnderecoRequestJson request);
}
