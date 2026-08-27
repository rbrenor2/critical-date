using System.ComponentModel.DataAnnotations;
using CriticalDate.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CriticalDate.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Products.AnyAsync())
            return;

        const int length = 10;
        for (int i = 0; i < length; i++)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Sku = $"{Guid.NewGuid()}",
                Name = $"Milk {i}"
            };

            var rnd = new Random(i);
            var c = i+1;
            var store = new Store
            {
                Id = Guid.NewGuid(),
                Name = $"{Guid.NewGuid()}",
                MonthlyMarkdownBudget = rnd.Next(30000, 50000),
                UsedMarkdownBudget = rnd.Next(3500, 79000)
            };

            var inventoryItem = new InventoryItem
            {
                Id = Guid.NewGuid(),
                Product = product,
                Store = store,
                CurrentPrice = rnd.Next(1, 40),
                Quantity = rnd.Next(1, 40),
                ExpirationDate = DateTime.UtcNow.AddDays(i)
            };

            db.AddRange(product, store, inventoryItem);
            await db.SaveChangesAsync();
        }
    }
}