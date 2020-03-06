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
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1L,
                            Date = new DateTime(2020, 3, 6, 13, 30, 44, 663, DateTimeKind.Local).AddTicks(6365),
                            StoreId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            OrderId = 2L,
                            Date = new DateTime(2020, 3, 6, 13, 30, 44, 663, DateTimeKind.Local).AddTicks(6983),
                            StoreId = 2L,
                            UserId = 2L
                        },
                        new
                        {
                            OrderId = 3L,
                            Date = new DateTime(2020, 3, 6, 13, 30, 44, 663, DateTimeKind.Local).AddTicks(7008),
                            StoreId = 1L,
                            UserId = 2L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderPizza", b =>
                {
                    b.Property<long>("OrderPizzaId")
                        .HasColumnType("bigint");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("PizzaId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderPizzaId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderPizza");

                    b.HasData(
                        new
                        {
                            OrderPizzaId = 1L,
                            Amount = 2,
                            OrderId = 1L,
                            PizzaId = 3L
                        },
                        new
                        {
                            OrderPizzaId = 2L,
                            Amount = 3,
                            OrderId = 1L,
                            PizzaId = 5L
                        },
                        new
                        {
                            OrderPizzaId = 3L,
                            Amount = 1,
                            OrderId = 2L,
                            PizzaId = 2L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.Property<long>("PizzaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumMenu")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizza");

                    b.HasData(
                        new
                        {
                            PizzaId = 1L,
                            Description = "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Name = "SMALL HAWAIIAN PIZZA",
                            NumMenu = 1,
                            Price = 5.00m
                        },
                        new
                        {
                            PizzaId = 2L,
                            Description = "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Name = "MEDIUM HAWAIIAN PIZZA",
                            NumMenu = 2,
                            Price = 9.50m
                        },
                        new
                        {
                            PizzaId = 3L,
                            Description = "thin crust, tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Name = "LARGE HAWAIIAN PIZZA",
                            NumMenu = 3,
                            Price = 13.90m
                        },
                        new
                        {
                            PizzaId = 4L,
                            Description = "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Name = "SMALL EXQUISITE PIZZA",
                            NumMenu = 4,
                            Price = 6.00m
                        },
                        new
                        {
                            PizzaId = 5L,
                            Description = "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Name = "MEDIUM EXQUISITE PIZZA",
                            NumMenu = 5,
                            Price = 11.00m
                        },
                        new
                        {
                            PizzaId = 6L,
                            Description = "flatbread, tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Name = "LARGE EXQUISITE PIZZA",
                            NumMenu = 6,
                            Price = 15.50m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

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
                            StoreId = 1L,
                            Address = "Cooper 786",
                            Name = "MammaMía",
                            NumMenu = 1,
                            Password = "13131"
                        },
                        new
                        {
                            StoreId = 2L,
                            Address = "Mitchel 83",
                            Name = "DiegoPizza",
                            NumMenu = 2,
                            Password = "58585"
                        },
                        new
                        {
                            StoreId = 3L,
                            Address = "Mesquite 476",
                            Name = "MyPizza",
                            NumMenu = 3,
                            Password = "lolol"
                        },
                        new
                        {
                            StoreId = 4L,
                            Address = "Abram 34",
                            Name = "TuPizza",
                            NumMenu = 4,
                            Password = "trole"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

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
                            UserId = 1L,
                            Address = "Central 960",
                            Name = "BiancaVisconti",
                            Password = "12345"
                        },
                        new
                        {
                            UserId = 2L,
                            Address = "Street 4250",
                            Name = "SilvanaRoncagliolo",
                            Password = "67890"
                        },
                        new
                        {
                            UserId = 3L,
                            Address = "Calle 13",
                            Name = "JuanitoPerez",
                            Password = "asasa"
                        },
                        new
                        {
                            UserId = 4L,
                            Address = "Avenida 89",
                            Name = "MariaSoto",
                            Password = "trebol"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
#pragma warning restore 612, 618
        }
    }
}
