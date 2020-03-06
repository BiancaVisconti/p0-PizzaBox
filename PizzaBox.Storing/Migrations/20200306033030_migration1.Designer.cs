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
    [Migration("20200306033030_migration1")]
    partial class migration1
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
                            PizzaId = 637190406300436451L,
                            Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Inventory = 30,
                            Name = "small hawaiian pizza",
                            NumMenu = 1,
                            Price = 5.00m
                        },
                        new
                        {
                            PizzaId = 637190406300437879L,
                            Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Inventory = 18,
                            Name = "medium hawaiian pizza",
                            NumMenu = 2,
                            Price = 9.50m
                        },
                        new
                        {
                            PizzaId = 637190406300437926L,
                            Description = "tomato sauce, vegan mozzarella, pineapple, green pepper, onions",
                            Inventory = 12,
                            Name = "large hawaiian pizza",
                            NumMenu = 3,
                            Price = 13.90m
                        },
                        new
                        {
                            PizzaId = 637190406300437929L,
                            Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Inventory = 24,
                            Name = "small exquisite pizza",
                            NumMenu = 4,
                            Price = 6.00m
                        },
                        new
                        {
                            PizzaId = 637190406300437931L,
                            Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Inventory = 30,
                            Name = "medium exquisite pizza",
                            NumMenu = 5,
                            Price = 11.00m
                        },
                        new
                        {
                            PizzaId = 637190406300437932L,
                            Description = "tomato sauce, vegan mozzarella, tomatos, avocado, tofu, onions",
                            Inventory = 17,
                            Name = "large exquisite pizza",
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
                            StoreId = 637190406300380263L,
                            Address = "Cooper 786",
                            Name = "Mamma Mía",
                            NumMenu = 1,
                            Password = "13131"
                        },
                        new
                        {
                            StoreId = 637190406300380768L,
                            Address = "Mitchel 83",
                            Name = "Diego Pizza",
                            NumMenu = 2,
                            Password = "58585"
                        },
                        new
                        {
                            StoreId = 637190406300380795L,
                            Address = "Mesquite 476",
                            Name = "My Pizza",
                            NumMenu = 3,
                            Password = "lolol"
                        },
                        new
                        {
                            StoreId = 637190406300380797L,
                            Address = "Abram 34",
                            Name = "Tu Pizza",
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
                            UserId = 637190406300342160L,
                            Address = "Central 960",
                            Name = "BiancaVisconti",
                            Password = "12345"
                        },
                        new
                        {
                            UserId = 637190406300364055L,
                            Address = "Street 4250",
                            Name = "SilvanaRoncagliolo",
                            Password = "67890"
                        },
                        new
                        {
                            UserId = 637190406300364094L,
                            Address = "Calle 13",
                            Name = "JuanitoPerez",
                            Password = "asasa"
                        },
                        new
                        {
                            UserId = 637190406300364097L,
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
