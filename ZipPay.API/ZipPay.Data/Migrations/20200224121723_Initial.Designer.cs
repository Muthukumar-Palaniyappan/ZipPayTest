﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Migrations
{
    [DbContext(typeof(ZipEntities))]
    [Migration("20200224121723_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZipPay.Data.Entities.AccountEntity", b =>
                {
                    b.Property<long>("AccountNumber");

                    b.Property<decimal>("Balance");

                    b.Property<bool>("IsAccountActive");

                    b.Property<Guid>("UserId");

                    b.HasKey("AccountNumber")
                        .HasName("PK_AccountEntity_AccountNumber");

                    b.HasIndex("UserId");

                    b.ToTable("AccountEntities");
                });

            modelBuilder.Entity("ZipPay.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<decimal>("MonthlyExpense")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MonthlyIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserName");

                    b.HasKey("UserId")
                        .HasName("PK_UserEntity_EmailAddress");

                    b.ToTable("UserEntities");
                });

            modelBuilder.Entity("ZipPay.Data.Entities.AccountEntity", b =>
                {
                    b.HasOne("ZipPay.Data.Entities.UserEntity", "UserEntity")
                        .WithMany("AccountEntities")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AccountEntity_UserEntity")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}