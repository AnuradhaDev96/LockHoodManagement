using Microsoft.EntityFrameworkCore;
using MSS_API.Models.AutomatedWarehouseRequests;
using MSS_API.Models.Decisions;
using MSS_API.Models.Departments;
using MSS_API.Models.EmployeeUsers;
using MSS_API.Models.Factories;
using MSS_API.Models.Inventories;
using MSS_API.Models.WorkMonitoring;
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

        public DbSet<Department> Departments { get; set; }

        public DbSet<EmployeeUser> EmployeeUsers { get; set; }
        
        public DbSet<Factory> Factories { get; set; }
        
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        
        public DbSet<AutomatedWarehouseRequest> AutomatedWarehouseRequests { get; set; }
        
        public DbSet<AutomatedRequestWarehouseItem> AutomatedWarehouseRequestItems { get; set; }
        
        public DbSet<ProductionBatch> ProductionBatches { get; set; }
        
        public DbSet<ManagementDecisions> ManagementDecisions { get; set; }
        
        public DbSet<EmployeePerformance> EmployeePerformances { get; set; }
        
        public DbSet<KanBanTask> KanBanTasks { get; set; }

        public DbSet<TaskAllocatedResource> TaskAllocatedResources { get; set; }

        //For Many-Many relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutomatedRequestWarehouseItem>()
                .HasKey(i => new { i.RequestId, i.ProductCode });

            modelBuilder.Entity<AutomatedRequestWarehouseItem>()
                .HasOne(ai => ai.AutomatedWarehouseRequest)
                .WithMany(a => a.AutomatedRequestWarehouseItems)
                .HasForeignKey(ai => ai.RequestId);

            modelBuilder.Entity<AutomatedRequestWarehouseItem>()
                .HasOne(ai => ai.WarehouseItem)
                .WithMany(w => w.AutomatedRequestWarehouseItems)
                .HasForeignKey(ai => ai.ProductCode);

            modelBuilder.Entity<KanBanTask>()
                .HasOne(kbt => kbt.ProductionBatch)
                .WithMany(p => p.KanBanTasks)
                .HasForeignKey(kbt => kbt.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KanBanTask>()
                .HasOne(kbt => kbt.Labourer)
                .WithMany(e => e.KanBanTasks)
                .HasForeignKey(kbt => kbt.LabourerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
