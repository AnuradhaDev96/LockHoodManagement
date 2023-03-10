// <auto-generated />
using System;
using MSS_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSSAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230105154310_AddAutomatedEntities")]
    partial class AddAutomatedEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MSS_API.Models.AutomatedWarehouseRequests.AutomatedRequestWarehouseItem", b =>
                {
                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("RequestId", "ProductCode");

                    b.HasIndex("ProductCode");

                    b.ToTable("AutomatedWarehouseRequestItems");
                });

            modelBuilder.Entity("MSS_API.Models.AutomatedWarehouseRequests.AutomatedWarehouseRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("AutomatedWarehouseRequests");
                });

            modelBuilder.Entity("MSS_API.Models.Departments.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("DepartmentType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MSS_API.Models.EmployeeUsers.EmployeeUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("EmployeeUsers");
                });

            modelBuilder.Entity("MSS_API.Models.Factories.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("MSS_API.Models.Inventories.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("MSS_API.Models.Inventories.InventoryItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AlertMargin")
                        .HasColumnType("float");

                    b.Property<double>("AvailableQuantity")
                        .HasColumnType("float");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("MSS_API.Models.Workshops.WarehouseItem", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AvailableQuantity")
                        .HasColumnType("float");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCode");

                    b.ToTable("WarehouseItems");
                });

            modelBuilder.Entity("MSS_API.Models.Workshops.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("MSS_API.Models.AutomatedWarehouseRequests.AutomatedRequestWarehouseItem", b =>
                {
                    b.HasOne("MSS_API.Models.Workshops.WarehouseItem", "WarehouseItem")
                        .WithMany("AutomatedRequestWarehouseItems")
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MSS_API.Models.AutomatedWarehouseRequests.AutomatedWarehouseRequest", "AutomatedWarehouseRequest")
                        .WithMany("AutomatedRequestWarehouseItems")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutomatedWarehouseRequest");

                    b.Navigation("WarehouseItem");
                });

            modelBuilder.Entity("MSS_API.Models.AutomatedWarehouseRequests.AutomatedWarehouseRequest", b =>
                {
                    b.HasOne("MSS_API.Models.Inventories.Inventory", "Inventory")
                        .WithMany("AutomatedWarehouseRequests")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("MSS_API.Models.EmployeeUsers.EmployeeUser", b =>
                {
                    b.HasOne("MSS_API.Models.Departments.Department", "Department")
                        .WithMany("EmployeeUsers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MSS_API.Models.Inventories.Inventory", b =>
                {
                    b.HasOne("MSS_API.Models.Workshops.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("MSS_API.Models.Inventories.InventoryItems", b =>
                {
                    b.HasOne("MSS_API.Models.Inventories.Inventory", "Inventory")
                        .WithMany("InventoryItems")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("MSS_API.Models.AutomatedWarehouseRequests.AutomatedWarehouseRequest", b =>
                {
                    b.Navigation("AutomatedRequestWarehouseItems");
                });

            modelBuilder.Entity("MSS_API.Models.Departments.Department", b =>
                {
                    b.Navigation("EmployeeUsers");
                });

            modelBuilder.Entity("MSS_API.Models.Inventories.Inventory", b =>
                {
                    b.Navigation("AutomatedWarehouseRequests");

                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("MSS_API.Models.Workshops.WarehouseItem", b =>
                {
                    b.Navigation("AutomatedRequestWarehouseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
