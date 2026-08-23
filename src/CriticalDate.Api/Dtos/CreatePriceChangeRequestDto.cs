namespace CriticalDate.Api.Dtos;

public class CreatePriceChangeRequestDto
{
    public Guid InventoryItemId {get; set;}
    public decimal RequestedPrice {get; set;}
}