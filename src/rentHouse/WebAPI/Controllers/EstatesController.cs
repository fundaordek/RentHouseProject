using Application.Features.Estates.Commands.Create;
using Application.Features.Estates.Commands.Delete;
using Application.Features.Estates.Commands.Update;
using Application.Features.Estates.Queries.GetById;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEstateCommand createEstateCommand)
    {
        CreatedEstateResponse response = await Mediator.Send(createEstateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEstateCommand updateEstateCommand)
    {
        UpdatedEstateResponse response = await Mediator.Send(updateEstateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedEstateResponse response = await Mediator.Send(new DeleteEstateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdEstateResponse response = await Mediator.Send(new GetByIdEstateQuery { Id = id });
        return Ok(response);
    }

}
