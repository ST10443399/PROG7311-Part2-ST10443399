using PROG7311_ST10443399_POE.Models;
using Microsoft.EntityFrameworkCore;

namespace PROG7311_ST10443399_POE.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
