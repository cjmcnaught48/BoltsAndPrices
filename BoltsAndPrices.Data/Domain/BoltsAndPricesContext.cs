using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BoltsAndPrices.Data.Domain
{
    public class BoltsAndPricesContext : DbContext
    {
        public BoltsAndPricesContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = ConfigurationManager.AppSettings["DatabasePath"], //"C:\\BoltsAndPrices\\BoltsAndPrices.Data\\BoltsAndPrices.sqlite", 
                    ForeignKeys = true 
                }.ConnectionString
            }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //this.Configuration.LazyLoadingEnabled = false;

            modelBuilder.Configurations.Add(new InventoryEntityConfiguration());
            modelBuilder.Configurations.Add(new InvoiceEntityConfiguration());
            modelBuilder.Configurations.Add(new InvoiceInventoryEntityConfiguration());
            
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Inventory> Bolts { get; set; }
        //public DbSet<Invoice> Invoices { get; set; }
        //public DbSet<InvoiceInventory> InvoiceInventorys { get; set; }
    }

    public class InventoryEntityConfiguration : EntityTypeConfiguration<Inventory>
    {
        public InventoryEntityConfiguration()
        {
            this.ToTable("Inventory");

            this.HasKey<int>(i => i.InventoryId);

            //this.Property(i => i.InventoryCode).HasColumnName("InventoryCode");
            //this.Property(i => i.Price).HasColumnName("Price");

        }
    
    }

    public class InvoiceEntityConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceEntityConfiguration()
        {
            this.ToTable("Invoice");

            this.HasKey<int>(i => i.InvoiceId);

            this.HasMany<InvoiceInventory>(i => i.InvoiceInventories).WithRequired(j => j.Invoice);

        }
    }

    public class InvoiceInventoryEntityConfiguration : EntityTypeConfiguration<InvoiceInventory>
    {
        public InvoiceInventoryEntityConfiguration()
        {
            this.ToTable("InvoiceInventory");

            this.HasKey<int>(i => i.InvoiceInventoryId);

            this.HasRequired<Invoice>(i => i.Invoice).WithMany(i => i.InvoiceInventories);

        }
    }
}