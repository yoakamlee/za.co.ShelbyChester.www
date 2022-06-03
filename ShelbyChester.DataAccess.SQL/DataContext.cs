using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<ClientPreAdvice> clientPreAdvices { get; set; }
        public DbSet<ContainerCategory> containerCategories { get; set; }
        public DbSet<FreightQuotation> freightQuotations { get; set; }
        public DbSet<WarehouseStorage> warehouseStorages { get; set; }
        public DbSet<ContainerRental> containerRentals { get; set; }
    }
}
