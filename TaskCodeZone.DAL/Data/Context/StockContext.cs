using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public class StockContext : DbContext
    {
        public DbSet<Store> stores { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public StockContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluint api
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
