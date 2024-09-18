using LoremIpsumLogistica.API.Request;
using LoremIpsumLogistica.API.Responses;
using LoremIpsumLogistica.API.UseCase.Cadastro;
using Microsoft.AspNetCore.Mvc;

namespace LoremIpsumLogistica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CadastrosController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(CadastrosResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> BuscarTodos([FromServices] IBuscarTodosUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Cadastros.Any())
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(CadastroResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CadastroById(
        [FromServices] ICadastroByIdUseCase useCase,
        [FromRoute] long id
        )
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Models.Cadastro), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Salvar(
        [FromServices] ISalvarCadastroUseCase useCase,
        [FromBody] CadastroRequestJson request
    )
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IAtualizarUseCase useCase,
        [FromRoute] long id,
        [FromBody] CadastroRequestJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
            [FromServices] IExcluirCadastroUseCase useCase,
            [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
