using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoremIpsumLogistica.API.Request;
using LoremIpsumLogistica.API.Responses;
using LoremIpsumLogistica.API.UseCase.Endereco;
using Microsoft.AspNetCore.Mvc;

namespace LoremIpsumLogistica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecosController : ControllerBase
{
    [HttpGet]
    [Route("cadastro-id/{id}")]
    [ProducesResponseType(typeof(EnderecoResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EnderecosByCadastroId(
            [FromServices] IBuscaByIdCadastroUseCase useCase,
            [FromRoute] long id
            )
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(EnderecoResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EnderecoById(
            [FromServices] IEnderecoByIdUseCase useCase,
            [FromRoute] long id
            )
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(EnderecoResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Salvar(
            [FromServices] ISalvarEnderecoUseCase useCase,
            [FromBody] EnderecoRequestJson request
        )
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar(
        [FromServices] IAtualizarEnderecoUseCase useCase,
        [FromRoute] long id,
        [FromBody] EnderecoRequestJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Excluir(
            [FromServices] IExcluirEnderecoUseCase useCase,
            [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
