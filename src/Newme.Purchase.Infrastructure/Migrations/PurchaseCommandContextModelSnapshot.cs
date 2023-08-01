﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newme.Purchase.Infrastructure.Persistence;

#nullable disable

namespace Newme.Purchase.Infrastructure.Migrations
{
    [DbContext(typeof(PurchaseCommandContext))]
    partial class PurchaseCommandContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

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
                            Id = new Guid("9566dea4-7c7e-41b1-97e4-1c7bef79adf8"),
                            Description = "item de compra criado",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("1263d8ed-c935-443c-98b6-47c9a1a795b1"),
                            Description = "item de compra não aprovado porque o produto estava fora de estoque",
                            Status = 2
                        },
                        new
                        {
                            Id = new Guid("e965659f-bd46-4483-b4a3-3647c2654246"),
                            Description = "item de compra parcialmente aprovado",
                            Status = 3
                        },
                        new
                        {
                            Id = new Guid("459ee5f1-f1f9-4820-be9c-5628e7a201c7"),
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
                            Id = new Guid("b7f9f558-8556-4b85-a516-6a92db138def"),
                            Description = "inicial",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("b5a17818-693d-4b6a-af68-e525e88a3d23"),
                            Description = "validação do pagamento",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("6e09a39b-3d6a-43d2-af97-196fc03fda77"),
                            Description = "pagamento autorizado",
                            Status = 2
                        },
                        new
                        {
                            Id = new Guid("a175401c-16e8-4bd2-a47e-5aa42282fad0"),
                            Description = "pagamento não autorizado",
                            Status = 3
                        },
                        new
                        {
                            Id = new Guid("cae60eb5-4217-4a8f-b200-f89ebd4e951f"),
                            Description = "compra não aprovada porque o produto estava fora de estoque",
                            Status = 4
                        },
                        new
                        {
                            Id = new Guid("ce5d3651-7b88-4ee0-8fbb-1b02f840a27b"),
                            Description = "compra aprovada com itens faltantes",
                            Status = 5
                        },
                        new
                        {
                            Id = new Guid("5d7b0f59-a59f-4766-926d-34786d4c0f5c"),
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
                        .WithMany()
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

            modelBuilder.Entity("Newme.Purchase.Domain.Models.Entities.PurchaseOrder", b =>
                {
                    b.Navigation("PurchaseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
