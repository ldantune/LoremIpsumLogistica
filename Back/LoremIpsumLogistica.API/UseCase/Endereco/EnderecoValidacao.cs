using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Endereco;

public class EnderecoValidacao : AbstractValidator<EnderecoRequestJson>
{
    public EnderecoValidacao()
    {
        RuleFor(endereco => endereco.CEP).NotEmpty().WithMessage("O CEP deve ser informado");
        RuleFor(endereco => endereco.Logradouro).NotEmpty().WithMessage("O logradouro deve ser informado");
        RuleFor(endereco => endereco.Numero).NotEmpty().WithMessage("O número deve ser informado");
        RuleFor(endereco => endereco.Cidade).NotEmpty().WithMessage("A cidade deve ser informada");
        RuleFor(endereco => endereco.UF).NotEmpty().WithMessage("A UF deve ser informado");
    }
}
