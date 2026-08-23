using CriticalDate.Api.Dtos;

namespace CriticalDate.Api.Services;

public interface IPriceChangeService
{
    PriceChangeRequestResponseDto Create(CreatePriceChangeRequestDto request);
}
