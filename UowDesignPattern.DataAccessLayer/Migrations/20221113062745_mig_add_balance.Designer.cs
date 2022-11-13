﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UowDesignPattern.DataAccessLayer.Concrete;

namespace UowDesignPattern.DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221113062745_mig_add_balance")]
    partial class mig_add_balance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.BankAccountDetail", b =>
                {
                    b.Property<int>("BankAccountDetailID")
                        .HasColumnType("int");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankAccountDetailID");

                    b.ToTable("BankAccountDetails");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.BankAccountDetail", b =>
                {
                    b.HasOne("UowDesignPattern.EntityLayer.Concrete.Customer", "Customer")
                        .WithOne("BankAccountDetail")
                        .HasForeignKey("UowDesignPattern.EntityLayer.Concrete.BankAccountDetail", "BankAccountDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Customer", b =>
                {
                    b.Navigation("BankAccountDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
