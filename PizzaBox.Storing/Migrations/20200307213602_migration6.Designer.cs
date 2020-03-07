﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxDbContext))]
    [Migration("20200307213602_migration6")]
    partial class migration6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Date = new DateTime(2020, 3, 1, 7, 9, 14, 0, DateTimeKind.Unspecified),
                            StoreId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            OrderId = 2L,
                            Date = new DateTime(2020, 2, 17, 7, 9, 14, 0, DateTimeKind.Unspecified),
                            StoreId = 2L,
                            UserId = 2L
                        },
                        new
                        {
                            OrderId = 3L,
                            Date = new DateTime(2020, 3, 5, 7, 9, 14, 0, DateTimeKind.Unspecified),
                            StoreId = 1L,
                            UserId = 2L
                        },
                        new
                        {
                            OrderId = 4L,
                            Date = new DateTime(2020, 3, 6, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            OrderId = 5L,
                            Date = new DateTime(2020, 3, 6, 15, 9, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 2L,
                            UserId = 2L
                        },
                        new
                        {
                            OrderId = 6L,
                            Date = new DateTime(2020, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 6L,
                            UserId = 9L
                        },
                        new
                        {
                            OrderId = 7L,
                            Date = new DateTime(2020, 1, 6, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 5L,
                            UserId = 10L
                        },
                        new
                        {
                            OrderId = 8L,
                            Date = new DateTime(2019, 11, 12, 14, 25, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 4L,
                            UserId = 7L
                        },
                        new
                        {
                            OrderId = 9L,
                            Date = new DateTime(2019, 12, 31, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 3L,
                            UserId = 8L
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
                        },
                        new
                        {
                            OrderPizzaId = 4L,
                            Amount = 1,
                            OrderId = 3L,
                            PizzaId = 4L
                        },
                        new
                        {
                            OrderPizzaId = 5L,
                            Amount = 2,
                            OrderId = 4L,
                            PizzaId = 6L
                        },
                        new
                        {
                            OrderPizzaId = 6L,
                            Amount = 1,
                            OrderId = 5L,
                            PizzaId = 2L
                        },
                        new
                        {
                            OrderPizzaId = 7L,
                            Amount = 3,
                            OrderId = 6L,
                            PizzaId = 7L
                        },
                        new
                        {
                            OrderPizzaId = 8L,
                            Amount = 1,
                            OrderId = 6L,
                            PizzaId = 8L
                        },
                        new
                        {
                            OrderPizzaId = 9L,
                            Amount = 7,
                            OrderId = 7L,
                            PizzaId = 9L
                        },
                        new
                        {
                            OrderPizzaId = 10L,
                            Amount = 2,
                            OrderId = 7L,
                            PizzaId = 6L
                        },
                        new
                        {
                            OrderPizzaId = 11L,
                            Amount = 3,
                            OrderId = 8L,
                            PizzaId = 5L
                        },
                        new
                        {
                            OrderPizzaId = 12L,
                            Amount = 1,
                            OrderId = 8L,
                            PizzaId = 1L
                        },
                        new
                        {
                            OrderPizzaId = 13L,
                            Amount = 2,
                            OrderId = 9L,
                            PizzaId = 9L
                        },
                        new
                        {
                            OrderPizzaId = 14L,
                            Amount = 1,
                            OrderId = 9L,
                            PizzaId = 7L
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
                            Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions",
                            Name = "SMALL HAWAIIAN PIZZA",
                            NumMenu = 1,
                            Price = 5.00m
                        },
                        new
                        {
                            PizzaId = 2L,
                            Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions",
                            Name = "MEDIUM HAWAIIAN PIZZA",
                            NumMenu = 2,
                            Price = 9.50m
                        },
                        new
                        {
                            PizzaId = 3L,
                            Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions",
                            Name = "LARGE HAWAIIAN PIZZA",
                            NumMenu = 3,
                            Price = 13.90m
                        },
                        new
                        {
                            PizzaId = 4L,
                            Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions",
                            Name = "SMALL EXQUISITE PIZZA",
                            NumMenu = 4,
                            Price = 6.00m
                        },
                        new
                        {
                            PizzaId = 5L,
                            Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions",
                            Name = "MEDIUM EXQUISITE PIZZA",
                            NumMenu = 5,
                            Price = 11.00m
                        },
                        new
                        {
                            PizzaId = 6L,
                            Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions",
                            Name = "LARGE EXQUISITE PIZZA",
                            NumMenu = 6,
                            Price = 15.50m
                        },
                        new
                        {
                            PizzaId = 7L,
                            Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms",
                            Name = "SMALL DELICIOUS PIZZA",
                            NumMenu = 7,
                            Price = 5.50m
                        },
                        new
                        {
                            PizzaId = 8L,
                            Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms",
                            Name = "MEDIUM DELICIOUS PIZZA",
                            NumMenu = 8,
                            Price = 10.50m
                        },
                        new
                        {
                            PizzaId = 9L,
                            Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms",
                            Name = "LARGE DELICIOUS PIZZA",
                            NumMenu = 9,
                            Price = 16.50m
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
                            Name = "PizzaEater",
                            NumMenu = 1,
                            Password = "eater"
                        },
                        new
                        {
                            StoreId = 2L,
                            Address = "Mitchel 83",
                            Name = "DiegoPizza",
                            NumMenu = 2,
                            Password = "diego"
                        },
                        new
                        {
                            StoreId = 3L,
                            Address = "Mesquite 476",
                            Name = "MiPizza",
                            NumMenu = 3,
                            Password = "pizza"
                        },
                        new
                        {
                            StoreId = 4L,
                            Address = "Abram 34",
                            Name = "TuPizza",
                            NumMenu = 4,
                            Password = "pizza"
                        },
                        new
                        {
                            StoreId = 5L,
                            Address = "Cooper 132",
                            Name = "Mangiata",
                            NumMenu = 5,
                            Password = "comer"
                        },
                        new
                        {
                            StoreId = 6L,
                            Address = "Mesquite 87",
                            Name = "PizzaLover",
                            NumMenu = 6,
                            Password = "pizza"
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
                            Name = "Bianca",
                            Password = "bianca"
                        },
                        new
                        {
                            UserId = 2L,
                            Address = "Street 4250",
                            Name = "Silvana",
                            Password = "silvana"
                        },
                        new
                        {
                            UserId = 3L,
                            Address = "Calle 13",
                            Name = "Macarena",
                            Password = "maca"
                        },
                        new
                        {
                            UserId = 4L,
                            Address = "3 Poniente",
                            Name = "Victoria",
                            Password = "vicky"
                        },
                        new
                        {
                            UserId = 5L,
                            Address = "Avenida Beio 15",
                            Name = "Rufuz",
                            Password = "beio"
                        },
                        new
                        {
                            UserId = 6L,
                            Address = "15 Norte",
                            Name = "NancyCastro",
                            Password = "nancy"
                        },
                        new
                        {
                            UserId = 7L,
                            Address = "Avenida Beio 15",
                            Name = "Jenny",
                            Password = "jenny"
                        },
                        new
                        {
                            UserId = 8L,
                            Address = "Blanca Estela 76",
                            Name = "Fernanda",
                            Password = "ferna"
                        },
                        new
                        {
                            UserId = 9L,
                            Address = "Los Pellines 950",
                            Name = "Francisca",
                            Password = "fran"
                        },
                        new
                        {
                            UserId = 10L,
                            Address = "Lomas de Montenar 1190",
                            Name = "Sofia",
                            Password = "sofia"
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
