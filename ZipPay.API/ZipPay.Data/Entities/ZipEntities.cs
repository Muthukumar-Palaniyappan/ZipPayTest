using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZipPay.Data.Entities
{
    public class ZipEntities : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<AccountEntity> AccountEntities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbConnectionString = GetConnectionString();
            optionsBuilder.UseSqlServer(dbConnectionString);
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            return configuration.GetConnectionString("DBConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>().
                HasKey(p => p.UserId).
                HasName("PK_UserEntity_EmailAddress");

            modelBuilder.Entity<AccountEntity>().
                HasKey(p => p.AccountNumber).
                HasName("PK_AccountEntity_AccountNumber");



        }

    }
}
