using CriticalDate.Api.Dtos;
using CriticalDate.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CriticalDate.Api.Controllers;

[ApiController]
[Route("api/requests")]
public class PriceChangeRequestsController: ControllerBase
{
    private readonly IPriceChangeService _priceChangeService;

    public PriceChangeRequestsController(IPriceChangeService priceChangeService)
    {
        _priceChangeService = priceChangeService;
    }

    [HttpPost]
    public async Task<ActionResult<PriceChangeRequestResponseDto>> Create(CreatePriceChangeRequestDto request)
    {
        var result = await _priceChangeService.CreateAsync(request);

        return Ok(result);
    }
}