using Microsoft.EntityFrameworkCore;
using ParkManagment.Entities;

namespace ParkManagment.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Motor> Motors { get; set; }
        public DbSet<Staff> Staves { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        // public DbSet<EWallet> EWallets { get; set; }
    }
}