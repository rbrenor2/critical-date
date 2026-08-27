using System.Runtime.CompilerServices;
using CriticalDate.Api.Data;
using CriticalDate.Api.Dtos;
using CriticalDate.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CriticalDate.Api.Services;

public class PriceChangeService : IPriceChangeService
{
    private AppDbContext _db;

    public PriceChangeService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<PriceChangeRequestResponseDto> CreateAsync(CreatePriceChangeRequestDto request)
    {
        var inventoryItem = await _db.InventoryItems
        .FirstOrDefaultAsync(i => i.Id == request.InventoryItemId);

        if (inventoryItem is null)
        {
            throw new InvalidOperationException("Inventory item not found");
        }

        var changeRequest = new PriceChangeRequest
        {
            Id = Guid.NewGuid(),
            InventoryItem = inventoryItem,
            OriginalPrice = inventoryItem.CurrentPrice,
            RequestedPrice = request.RequestedPrice,
            CreatedAt = DateTime.UtcNow
        };

        _db.PriceChangeRequests.Add(changeRequest);
        await _db.SaveChangesAsync();


        var response = new PriceChangeRequestResponseDto
        {
            Id = changeRequest.Id,
            InventoryItemId = request.InventoryItemId,
            RequestedPrice = request.RequestedPrice,
            Status = PriceChangeRequestStatus.PendingReview
        };
        return response;
    }
}