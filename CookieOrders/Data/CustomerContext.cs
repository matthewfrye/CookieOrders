using Microsoft.EntityFrameworkCore;
using CookieOrders.Models;

namespace CookieOrders.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}