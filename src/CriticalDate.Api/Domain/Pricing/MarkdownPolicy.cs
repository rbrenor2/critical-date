using CriticalDate.Api.Models;

namespace CriticalDate.Api.Domain;

public class MarkdownPolicy
{
    public PriceChangeRequestStatus Evaluate(
        InventoryItem item, decimal requestedPrice
    )
    {
        var markdownImpact = (item.CurrentPrice - requestedPrice)*item.Quantity;
        var remainingBudget = item.Store.MonthlyMarkdownBudget - item.Store.UsedMarkdownBudget;

        return markdownImpact <= remainingBudget ? PriceChangeRequestStatus.Approved : PriceChangeRequestStatus.PendingReview;
    }
}