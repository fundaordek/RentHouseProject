using Application.Features.RentTypes.Commands.Create;
using Application.Features.RentTypes.Commands.Delete;
using Application.Features.RentTypes.Commands.Update;
using Application.Features.RentTypes.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRentTypeCommand createRentTypeCommand)
    {
        CreatedRentTypeResponse response = await Mediator.Send(createRentTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRentTypeCommand updateRentTypeCommand)
    {
        UpdatedRentTypeResponse response = await Mediator.Send(updateRentTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedRentTypeResponse response = await Mediator.Send(new DeleteRentTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdRentTypeResponse response = await Mediator.Send(new GetByIdRentTypeQuery { Id = id });
        return Ok(response);
    }

}