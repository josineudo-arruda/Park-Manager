using Microsoft.EntityFrameworkCore;

namespace AdministracaoShrekPark.Models;

public class ShrekParkManagerContext : DbContext
{
    public DbSet<Store> Stores { get; set; }
    public DbSet<Lavatory> Lavatories { get; set; }
    //public DbSet<Nursery> Nurseries { get; set; }
    //public DbSet<FastFoodStore> FastFoodStores { get; set; }
    public DbSet<FunFairToy> FunFairToys { get; set; }
    public DbSet<AquaticFunFairToy> AquaticFunFairToys { get; set; }

    public ShrekParkManagerContext(DbContextOptions<ShrekParkManagerContext> options) : base(options)
    {}
}