namespace CriticalDate.Api.Models;

public class PriceChangeRequest
{
    public Guid Id { get; set; }
    public Guid InventoryItemId { get; set; }
    public InventoryItem InventoryItem { get; set; } = null!;
    public decimal OriginalPrice { get; set; }
    public decimal RequestedPrice { get; set; }
    public int Quantity { get; set; }
    public PriceChangeRequestStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}