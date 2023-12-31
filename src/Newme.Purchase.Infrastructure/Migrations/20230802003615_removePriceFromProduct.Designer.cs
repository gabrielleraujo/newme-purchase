﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newme.Purchase.Infrastructure.Persistence;

#nullable disable

namespace Newme.Purchase.Infrastructure.Migrations
{
    [DbContext(typeof(PurchaseCommandContext))]
    [Migration("20230802003615_removePriceFromProduct")]
    partial class removePriceFromProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.Buyer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Surname");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Buyers", (string)null);
                });

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Category");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Color");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Desciption");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Size");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.PurchaseItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<Guid>("PurchaseOrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PurchaseOrderId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<double>("Refund")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Status");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseOrderItem", (string)null);
                });

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.PurchaseOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BuyerId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<Guid>("DiscountCouponId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DiscountCouponId");

                    b.Property<double>("FreightValue")
                        .HasColumnType("float")
                        .HasColumnName("FreightValue");

                    b.Property<bool>("HasDiscountCoupon")
                        .HasColumnType("bit")
                        .HasColumnName("HasDiscountCoupon");

                    b.Property<bool>("HasSummary")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.Property<double>("PurchseDiscountValue")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("PurchaseOrder", (string)null);
                });

            modelBuilder.Entity("Newme.Purchase.Infrastructure.Configurations.Utils.PurchaseOrderItemStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("PurchaseOrderItemStatus", (string)null);

                    b.UseTpcMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = new Guid("c070b697-8ea1-4ae3-98b0-a1e6d10b117b"),
                            Description = "item de compra criado",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("648ee8d4-e16e-4b06-b20d-de77f13b29c9"),
                            Description = "item de compra não aprovado porque o produto estava fora de estoque",
                            Status = 2
                        },
                        new
                        {
                            Id = new Guid("016793a3-dd06-4533-87a5-d5d44251b418"),
                            Description = "item de compra parcialmente aprovado",
                            Status = 3
                        },
                        new
                        {
                            Id = new Guid("c7bee533-19e9-457e-9bab-bd1038ef486b"),
                            Description = "item de compra aprovado",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Newme.Purchase.Infrastructure.Configurations.Utils.PurchaseOrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("PurchaseOrderStatus", (string)null);

                    b.UseTpcMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = new Guid("ffc43c28-2a5d-471b-b70c-49d42fbf6d5d"),
                            Description = "inicial",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("e016e397-0371-46cd-abf9-32c3862ff33e"),
                            Description = "validação do pagamento",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("5be51086-a19c-4dab-9ec1-4dd2996cfe41"),
                            Description = "pagamento autorizado",
                            Status = 2
                        },
                        new
                        {
                            Id = new Guid("0b779177-2467-48d9-980f-6f64cbe3b828"),
                            Description = "pagamento não autorizado",
                            Status = 3
                        },
                        new
                        {
                            Id = new Guid("9377149a-77a4-4849-b4fd-14520e096737"),
                            Description = "compra não aprovada porque o produto estava fora de estoque",
                            Status = 4
                        },
                        new
                        {
                            Id = new Guid("43e8604b-064d-47a0-a8d6-34148d6cf23b"),
                            Description = "compra aprovada com itens faltantes",
                            Status = 5
                        },
                        new
                        {
                            Id = new Guid("b159c09c-a785-4a8c-91be-f95b6bb0f6cf"),
                            Description = "compra aprovada",
                            Status = 6
                        });
                });

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.PurchaseItem", b =>
                {
                    b.HasOne("Newme.Purchase.Domain.Models.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Newme.Purchase.Domain.Models.Entities.PurchaseOrder", null)
                        .WithMany("PurchaseItems")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.PurchaseOrder", b =>
                {
                    b.HasOne("Newme.Purchase.Domain.Models.Entities.Buyer", "Buyer")
                        .WithMany("Purchases")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Newme.Purchase.Domain.Models.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PurchaseOrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Neighborhood");

                            b1.Property<int>("Number")
                                .HasColumnType("int")
                                .HasColumnName("Number");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.Property<string>("UF")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UF");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("PurchaseOrderId");

                            b1.ToTable("PurchaseOrder");

                            b1.WithOwner()
                                .HasForeignKey("PurchaseOrderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.Buyer", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.PurchaseOrder", b =>
                {
                    b.Navigation("PurchaseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
