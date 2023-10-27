using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;

namespace Buberbreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BuberbreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BuberbreakfastController(IBreakfastService breakfastService)
    {
         _breakfastService = breakfastService;
    }


    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfatRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _breakfastService.CreateBreakfast(breakfast);

        var response = new CreateBreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);

        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id },
            value: response);

    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.CreateBreakfast(id);

        var response = new CreateBreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);

        return Ok(response);
    }

    [HttpPut("{id:Guid}")]
    public IActionResult UpdateBreakfast(Guid id, UpdateBreakfastRequest updateBreakfastRequest)
    {
        return Ok(updateBreakfastRequest);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}