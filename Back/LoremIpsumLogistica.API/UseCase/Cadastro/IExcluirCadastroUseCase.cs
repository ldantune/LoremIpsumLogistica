using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public interface IExcluirCadastroUseCase
{
    public Task Execute(long cadastroId);
}
