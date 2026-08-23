using CriticalDate.Api.Models;
namespace CriticalDate.Api.Dtos;

public class PriceChangeRequestResponseDto
{
    public Guid Id {get; set;}
    public Guid InventoryItemId {get; set;}
    public decimal RequestedPrice {get; set;}
    public PriceChangeRequestStatus Status {get;set;} = PriceChangeRequestStatus.PendingReview;
}