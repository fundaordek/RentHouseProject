using Application.Features.Rentals.Commands.Create;
using Application.Features.Rentals.Commands.Delete;
using Application.Features.Rentals.Commands.Update;
using Application.Features.Rentals.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRentalCommand createRentalCommand)
    {
        CreatedRentalResponse response = await Mediator.Send(createRentalCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRentalCommand updateRentalCommand)
    {
        UpdatedRentalResponse response = await Mediator.Send(updateRentalCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRentalResponse response = await Mediator.Send(new DeleteRentalCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRentalResponse response = await Mediator.Send(new GetByIdRentalQuery { Id = id });
        return Ok(response);
    }

}