using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PustokApp.Models;

namespace PustokApp.Data
{
    public class PustokDbContext(DbContextOptions<PustokDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Slider> Sliders { get; set; }
    }
}

