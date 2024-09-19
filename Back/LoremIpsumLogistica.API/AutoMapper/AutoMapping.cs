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
        CreateMap<EnderecoRequestJson, Models.Endereco>();
    }

    private void DomainToResponse()
    {
        CreateMap<Models.Cadastro, CadastroResponseJson>();
        CreateMap<Models.Endereco, EnderecoResponseJson>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()));
    }
}
