using AutoMapper;
using LoremIpsumLogistica.API.Request;
using LoremIpsumLogistica.API.Responses;

namespace LoremIpsumLogistica.API.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
        DomainToResponse();
    }

    private void RequestToDomain()
    {
        CreateMap<CadastroRequestJson, Models.Cadastro>();
    }

    private void DomainToResponse()
    {
        CreateMap<Models.Cadastro, CadastroResponseJson>();
    }
}
