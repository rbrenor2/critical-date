namespace CriticalDate.Api.Models;

public class Store
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal MonthlyMarkdownBudget { get; set; }

    public decimal UsedMarkdownBudget { get; set; }
}