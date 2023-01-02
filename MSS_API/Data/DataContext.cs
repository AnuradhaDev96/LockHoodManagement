using Microsoft.EntityFrameworkCore;
using MSS_API.Models.Inventories;
using MSS_API.Models.Workshops;

namespace MSS_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Workshop> Workshops { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<InventoryItems> InventoryItems { get; set; }

        //For Many-Many relationships
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Inventory>().HasKey(i=> new { i.Id, i.Name });
        //}
    }
}
