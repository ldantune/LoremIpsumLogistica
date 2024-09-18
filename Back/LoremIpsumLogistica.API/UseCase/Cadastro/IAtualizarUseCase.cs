using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public interface IAtualizarUseCase
{
    Task Execute(long cadastroId, CadastroRequestJson request);
}
