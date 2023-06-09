﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230128204703_mig_add_delete_anno")]
    partial class mig_add_delete_anno
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLayer.Concrete.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPermission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminUsername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Current", b =>
                {
                    b.Property<int>("CurrentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CurrentStatus")
                        .HasColumnType("bit");

                    b.Property<string>("CurrentSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrentID");

                    b.ToTable("Currents");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DepartmentStatus")
                        .HasColumnType("bit");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Expense", b =>
                {
                    b.Property<int>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpenseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ExpenseTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ExpenseID");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductMark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ProductStatus")
                        .HasColumnType("bit");

                    b.Property<short>("ProductStock")
                        .HasColumnType("smallint");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Receipt", b =>
                {
                    b.Property<int>("ReceiptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ReceiptDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiptLineNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptReceiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptSerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptSupplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptTaxAuthority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ReceiptTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReceiptID");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ReceiptDetail", b =>
                {
                    b.Property<int>("ReceiptDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ReceiptDetailsAmount")
                        .HasColumnType("int");

                    b.Property<string>("ReceiptDetailsDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ReceiptDetailsTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ReceiptDetailsUnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReceiptID")
                        .HasColumnType("int");

                    b.HasKey("ReceiptDetailsId");

                    b.HasIndex("ReceiptID");

                    b.ToTable("ReceiptDetails");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SalesMovement", b =>
                {
                    b.Property<int>("SalesMovementsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SalesMovementsDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SalesMovementsPrice")
                        .HasColumnType("int");

                    b.Property<int>("SalesMovementsTotal")
                        .HasColumnType("int");

                    b.Property<int>("SalesMovementsUnit")
                        .HasColumnType("int");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.HasKey("SalesMovementsID");

                    b.HasIndex("CurrentID");

                    b.HasIndex("ProductID");

                    b.HasIndex("StaffID");

                    b.ToTable("SalesMovements");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Staff", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("StaffImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StaffStatus")
                        .HasColumnType("bit");

                    b.Property<string>("StaffSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ReceiptDetail", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Receipt", "Receipt")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("ReceiptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SalesMovement", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Current", "Current")
                        .WithMany("SalesMovements")
                        .HasForeignKey("CurrentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Product", "Product")
                        .WithMany("SalesMovements")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Staff", "Staff")
                        .WithMany("SalesMovements")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Current");

                    b.Navigation("Product");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Staff", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Department", "Department")
                        .WithMany("Staffs")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Current", b =>
                {
                    b.Navigation("SalesMovements");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Department", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Navigation("SalesMovements");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Receipt", b =>
                {
                    b.Navigation("ReceiptDetails");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Staff", b =>
                {
                    b.Navigation("SalesMovements");
                });
#pragma warning restore 612, 618
        }
    }
}
