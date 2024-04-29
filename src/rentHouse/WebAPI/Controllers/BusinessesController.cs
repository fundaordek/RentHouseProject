using Application.Features.Businesses.Commands.Create;
using Application.Features.Businesses.Commands.Delete;
using Application.Features.Businesses.Commands.Update;
using Application.Features.Businesses.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBusinessCommand createBusinessCommand)
    {
        CreatedBusinessResponse response = await Mediator.Send(createBusinessCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBusinessCommand updateBusinessCommand)
    {
        UpdatedBusinessResponse response = await Mediator.Send(updateBusinessCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBusinessResponse response = await Mediator.Send(new DeleteBusinessCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBusinessResponse response = await Mediator.Send(new GetByIdBusinessQuery { Id = id });
        return Ok(response);
    }

}