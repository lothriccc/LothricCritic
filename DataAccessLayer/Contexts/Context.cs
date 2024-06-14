using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=ARDAPC\\SQLEXPRESS;database=DbLothricCritic;integrated security=true");
		}
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformGame>()
                .HasKey(gp => new { gp.PlatformID, gp.GameID });
            modelBuilder.Entity<GameCategory>()
                .HasKey(gc => new { gc.CategoryID, gc.GameID });
        }
    }
}
