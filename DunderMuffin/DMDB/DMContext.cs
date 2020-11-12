using Microsoft.EntityFrameworkCore;
using DMDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DMDB
{
    public class DMContext : DbContext
    {
        /// <summary>
        /// Making all the Table DbSets
        /// </summary>
        /// <value></value>

        public DbSet<InventoryItem> inventoryItems { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Employee> employees { get; set; }

        /// <summary>
        /// Used The OnConfiguring DbContext Options Builder to Establish a Connection To The Database Through The Connection String in 'appsetting.Json'
        /// </summary>
        /// <param name="optionsBuilder"></param>

        public DMContext(DbContextOptions<DMContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!(optionsBuilder.IsConfigured))
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("DMDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        /// <summary>
        /// Used The OnModelCreating Model Builder To Specify the Foreign Keys in my Associative Entities for EFCore
        /// </summary>
        /// <param name="modelBuilder"></param>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>()
            .HasKey(inv => new { inv.locationId, inv.productId });

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    employeeID = 1,
                    employeeFName = "Michelle",
                    employeeLName = "Scott",
                    employeeEmail = "MScott@DunderMuffin.com",
                    employeePassword = "password",
                    employeeType = "manager",
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    productId = 1,
                    productName = "Paper",
                    productDescription = "Dunder Muffin Brand Paper",
                    listPrice = 8.99,
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    productId = 2,
                    productName = "Pens",
                    productDescription = "Dunder Muffin Brand Pens",
                    listPrice = 2.99,
                }
            );
        }
    }
}