using CriticalDate.Api.Dtos;
using CriticalDate.Api.Models;

namespace CriticalDate.Api.Services;

public class PriceChangeService: IPriceChangeService
{
    public PriceChangeRequestResponseDto Create(CreatePriceChangeRequestDto request)
    {
        return new PriceChangeRequestResponseDto
        {
            Id = Guid.NewGuid(),
            InventoryItemId = request.InventoryItemId,
            RequestedPrice = request.RequestedPrice,
            Status = PriceChangeRequestStatus.Rejected
        };
    }
}