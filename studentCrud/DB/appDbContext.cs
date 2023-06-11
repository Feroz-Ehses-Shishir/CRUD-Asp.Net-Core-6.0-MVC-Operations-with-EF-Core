using Microsoft.EntityFrameworkCore;
using studentCrud.Models.DomainModel;

namespace studentCrud.DB
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<student> students { get; set; }
    }
}
