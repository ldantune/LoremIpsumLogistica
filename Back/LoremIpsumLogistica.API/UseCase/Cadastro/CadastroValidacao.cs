using FluentValidation;
using LoremIpsumLogistica.API.Request;

namespace LoremIpsumLogistica.API.UseCase.Cadastro;

public class CadastroValidacao : AbstractValidator<CadastroRequestJson>
{
    public CadastroValidacao()
    {
        RuleFor(cadastro => cadastro.Nome).NotEmpty().WithMessage("O nome deve ser informado");
        RuleFor(cadastro => cadastro.DataNascimento).NotEmpty().WithMessage("A data de nascimento deve ser informado");
        RuleFor(cadastro => cadastro.Sexo).NotEmpty().WithMessage("O sexo deve ser informado");
    }
}
