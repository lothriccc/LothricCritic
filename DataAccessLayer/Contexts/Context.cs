using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
	public class Context:IdentityDbContext<WriterUser,WriterRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-7E5MOF9\\SQLEXPRESS;database=DbLothricCritic;integrated security=true");
		}
       
        public DbSet<Game> Games { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PlatformGame> PlatformGame { get; set; }
        public DbSet<GameCategory> GameCategory { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<Test1> Tes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformGame>()
                .HasKey(gp => new { gp.PlatformID, gp.GameID });
            modelBuilder.Entity<GameCategory>()
                .HasKey(gc => new { gc.CategoryID, gc.GameID });
            //modelBuilder.Entity<Game>()
            //    .HasMany(g => g.Categories)
            //    .WithMany(c => c.Games)
            //    .UsingEntity<Dictionary<string, object>>(
            //    "GameCategory",
            //    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryID"),
            //    j => j.HasOne<Game>().WithMany().HasForeignKey("GameID"));

            base.OnModelCreating(modelBuilder);
        }
    }
}

