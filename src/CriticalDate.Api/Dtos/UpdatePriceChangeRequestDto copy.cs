using CriticalDate.Api.Models;

namespace CriticalDate.Api.Dtos;

public class UpdatePriceChangeRequestDto
{
    public Guid PriceChangeRequestId {get; set;}
    public PriceChangeRequestStatus Status {get; set;}
}