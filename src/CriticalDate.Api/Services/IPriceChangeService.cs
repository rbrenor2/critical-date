using CriticalDate.Api.Dtos;

namespace CriticalDate.Api.Services;

public interface IPriceChangeService
{
    Task<PriceChangeRequestResponseDto> CreateAsync(CreatePriceChangeRequestDto request);
    Task<PriceChangeAnalysisResponseDto> UpdateAsync(UpdatePriceChangeRequestDto request);
}
