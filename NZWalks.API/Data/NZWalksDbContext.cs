using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {

        }


        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data for difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("a8c61a88-9a05-4d42-a424-24842ddfb435"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a7063c30-1c87-43c9-bed1-0798edeb8fb3"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("59409221-372f-4347-9289-be9d46dddb44"),
                    Name = "Hard"
                }
            };

            //seed difficulties to thye database

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }

    }
}