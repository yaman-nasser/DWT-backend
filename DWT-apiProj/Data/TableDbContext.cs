using DWT_apiProj.Model;
using Microsoft.EntityFrameworkCore;

namespace DWT_apiProj.Data
{
    public class TableDbContext : DbContext
    {
        public TableDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
