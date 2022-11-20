using Inlamningsuppgift_1_WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Inlamningsuppgift_1_WebApi.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderRowEntity> OrderRows { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
