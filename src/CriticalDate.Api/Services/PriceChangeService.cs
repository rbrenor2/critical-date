using System.Runtime.CompilerServices;
using CriticalDate.Api.Data;
using CriticalDate.Api.Domain;
using CriticalDate.Api.Dtos;
using CriticalDate.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CriticalDate.Api.Services;

public class PriceChangeService : IPriceChangeService
{
    private AppDbContext _db;
    private MarkdownPolicy _markdownPolicy;

    public PriceChangeService(AppDbContext db, MarkdownPolicy markdownPolicy)
    {
        _db = db;
        _markdownPolicy = markdownPolicy;
    }
    public async Task<PriceChangeRequestResponseDto> CreateAsync(CreatePriceChangeRequestDto request)
    {
        var inventoryItem = await _db.InventoryItems
        .Include(i => i.Store)
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

        var status = _markdownPolicy.Evaluate(inventoryItem, request.RequestedPrice);

        _db.PriceChangeRequests.Add(changeRequest);
        await _db.SaveChangesAsync();


        var response = new PriceChangeRequestResponseDto
        {
            Id = changeRequest.Id,
            InventoryItemId = request.InventoryItemId,
            RequestedPrice = request.RequestedPrice,
            Status = status
        };
        return response;
    }
}