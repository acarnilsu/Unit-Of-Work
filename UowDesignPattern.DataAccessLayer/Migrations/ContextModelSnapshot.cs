﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UowDesignPattern.DataAccessLayer.Concrete;

namespace UowDesignPattern.DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SponsorTeam", b =>
                {
                    b.Property<int>("SponsorsSponsorID")
                        .HasColumnType("int");

                    b.Property<int>("TeamsTeamID")
                        .HasColumnType("int");

                    b.HasKey("SponsorsSponsorID", "TeamsTeamID");

                    b.HasIndex("TeamsTeamID");

                    b.ToTable("SponsorTeam");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.AccountTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer2ID")
                        .HasColumnType("int");

                    b.Property<string>("ReciverIban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReciverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SendIban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SendName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Customer2ID");

                    b.ToTable("accountTransactions");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Bank2", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Customer2ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Customer2ID");

                    b.ToTable("Bank2s");
                });

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

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Customer2", b =>
                {
                    b.Property<int>("Customer2ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Customer2ID");

                    b.ToTable("Customer2s");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Sponsor", b =>
                {
                    b.Property<int>("SponsorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SponsorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SponsorID");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SponsorTeam", b =>
                {
                    b.HasOne("UowDesignPattern.EntityLayer.Concrete.Sponsor", null)
                        .WithMany()
                        .HasForeignKey("SponsorsSponsorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UowDesignPattern.EntityLayer.Concrete.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.AccountTransaction", b =>
                {
                    b.HasOne("UowDesignPattern.EntityLayer.Concrete.Customer2", "Customer2")
                        .WithMany()
                        .HasForeignKey("Customer2ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer2");
                });

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Bank2", b =>
                {
                    b.HasOne("UowDesignPattern.EntityLayer.Concrete.Customer2", "Customer2")
                        .WithMany("Bank2s")
                        .HasForeignKey("Customer2ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer2");
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

            modelBuilder.Entity("UowDesignPattern.EntityLayer.Concrete.Customer2", b =>
                {
                    b.Navigation("Bank2s");
                });
#pragma warning restore 612, 618
        }
    }
}
