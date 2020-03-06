﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxDbContext))]
    partial class PizzaBoxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("StoreId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId1")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId");

                    b.HasIndex("StoreId1");

                    b.HasIndex("UserId1");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderPizza", b =>
                {
                    b.Property<long>("PizzaId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("PizzaId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.Property<long>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumMenu")
                        .HasColumnType("int");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PizzaId");

                    b.HasIndex("OrderId");

                    b.ToTable("Pizza");

                    b.HasData(
                        new
                        {
                            PizzaId = 637190552094955481L,
                            Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Inventory = 30,
                            Name = "SMALL HAWAIIAN PIZZA",
                            NumMenu = 1,
                            Price = 5.00m
                        },
                        new
                        {
                            PizzaId = 637190552094956851L,
                            Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Inventory = 18,
                            Name = "MEDIUM HAWAIIAN PIZZA",
                            NumMenu = 2,
                            Price = 9.50m
                        },
                        new
                        {
                            PizzaId = 637190552094956898L,
                            Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Inventory = 12,
                            Name = "LARGE HAWAIIAN PIZZA",
                            NumMenu = 3,
                            Price = 13.90m
                        },
                        new
                        {
                            PizzaId = 637190552094956900L,
                            Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Inventory = 24,
                            Name = "SMALL EXQUISITE PIZZA",
                            NumMenu = 4,
                            Price = 6.00m
                        },
                        new
                        {
                            PizzaId = 637190552094956903L,
                            Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Inventory = 30,
                            Name = "MEDIUM EXQUISITE PIZZA",
                            NumMenu = 5,
                            Price = 11.00m
                        },
                        new
                        {
                            PizzaId = 637190552094956906L,
                            Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Inventory = 17,
                            Name = "LARGE EXQUISITE PIZZA",
                            NumMenu = 6,
                            Price = 15.50m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Property<long>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumMenu")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            StoreId = 637190552094902343L,
                            Address = "Cooper 786",
                            Name = "MammaMía",
                            NumMenu = 1,
                            Password = "13131"
                        },
                        new
                        {
                            StoreId = 637190552094902839L,
                            Address = "Mitchel 83",
                            Name = "DiegoPizza",
                            NumMenu = 2,
                            Password = "58585"
                        },
                        new
                        {
                            StoreId = 637190552094902863L,
                            Address = "Mesquite 476",
                            Name = "MyPizza",
                            NumMenu = 3,
                            Password = "lolol"
                        },
                        new
                        {
                            StoreId = 637190552094902865L,
                            Address = "Abram 34",
                            Name = "TuPizza",
                            NumMenu = 4,
                            Password = "trole"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 637190552094865165L,
                            Address = "Central 960",
                            Name = "BiancaVisconti",
                            Password = "12345"
                        },
                        new
                        {
                            UserId = 637190552094886422L,
                            Address = "Street 4250",
                            Name = "SilvanaRoncagliolo",
                            Password = "67890"
                        },
                        new
                        {
                            UserId = 637190552094886461L,
                            Address = "Calle 13",
                            Name = "JuanitoPerez",
                            Password = "asasa"
                        },
                        new
                        {
                            UserId = 637190552094886464L,
                            Address = "Avenida 89",
                            Name = "MariaSoto",
                            Password = "trebol"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId1");

                    b.HasOne("PizzaBox.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderPizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Order", "Order")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Pizza", "Pizza")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("ListOfPizza")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
