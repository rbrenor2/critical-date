using CriticalDate.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CriticalDate.Api.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<Store> Store => Set<Store>();
    public DbSet<PriceChangeRequest> PriceChangeRequests => Set<PriceChangeRequest>();
}