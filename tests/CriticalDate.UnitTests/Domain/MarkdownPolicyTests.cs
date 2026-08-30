
using CriticalDate.Api.Domain;
using CriticalDate.Api.Models;

namespace CriticalDate.UnitTests.Domain;

public class MarkdownPolicyTests
{
    [Fact]
    public void Evaluate_WhenBudgetIsEnough_ReturnsApproved()
    {
        var policy = new MarkdownPolicy();

        var inventoryItem = new InventoryItem
        {
            CurrentPrice = 10m,
            Quantity = 10,
            Store = new Store
            {
                MonthlyMarkdownBudget = 100m,
                UsedMarkdownBudget = 0m
            }
        };

        var result = policy.Evaluate(inventoryItem, 5m);

        Assert.Equal(PriceChangeRequestStatus.Approved, result);
    }

    [Fact]
    public void Evaluate_WhenBudgetIsNotEnough_ReturnsPendingReview()
    {
        var policy = new MarkdownPolicy();

        var inventoryItem = new InventoryItem
        {
            CurrentPrice = 20m,
            Quantity = 10,
            Store = new Store
            {
                MonthlyMarkdownBudget = 100m,
                UsedMarkdownBudget = 10m
            }
        };

        var result = policy.Evaluate(inventoryItem, 5m);

        Assert.Equal(PriceChangeRequestStatus.PendingReview, result);
    }
}