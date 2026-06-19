using Microsoft.EntityFrameworkCore;
using TECHHUB.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TECHHUB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<HardwareInventory> HardwareInventories { get; set; }
        public DbSet<SoftwareLicense> SoftwareLicenses { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
    }
}
