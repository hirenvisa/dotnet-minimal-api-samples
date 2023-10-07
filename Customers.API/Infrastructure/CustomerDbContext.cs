using Customers.API.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Customers.API.Infrastructure;

public class CustomerDbContext: DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options): base(options) { }
    public DbSet<Customer> Customers => Set<Customer>();
}
