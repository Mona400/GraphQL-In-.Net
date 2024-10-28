using Commander_GraphQL.Models;
using Microsoft.EntityFrameworkCore;


namespace Commander_GraphQL.Data
{
	public class AppDbContext : DbContext
	{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<Platform> Platforms { get; set; }
		public DbSet<Command> Commands { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			

			modelBuilder.Entity<Platform>()
			 .HasMany(p => p.Commands)
			 .WithOne(c => c.Platform)
			 .HasForeignKey(c => c.PlatformId);


			modelBuilder
				.Entity<Command>()
				.HasOne(x => x.Platform)
				.WithMany(x => x.Commands)
				.HasForeignKey(x=>x.PlatformId)
				
				;
				




		}
	}
}
