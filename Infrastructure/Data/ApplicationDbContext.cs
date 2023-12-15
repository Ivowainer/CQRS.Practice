using CQRS.Practice.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practice.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaksItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}