using CriticalDate.Api.Models;

namespace CriticalDate.Api.Models;

public class InventoryItem
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public decimal CurrentPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime ExpirationDate { get; set; }
}