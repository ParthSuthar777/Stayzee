using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Stayzee.Domain.Entities;

namespace Stayzee.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(
                 new Villa
                 {
                     Id = 1,
                     Name = "Royal Villa",
                     Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                     ImageUrl = "https://placehold.co/600x400",
                     Occupancy = 4,
                     Price = 200,
                     Sqft = 550,
                 },
                new Villa
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://placehold.co/600x401",
                    Occupancy = 4,
                    Price = 300,
                    Sqft = 550,
                },
                new Villa
                {
                    Id = 3,
                    Name = "Luxury Pool Villa",
                    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://placehold.co/600x402",
                    Occupancy = 4,
                    Price = 400,
                    Sqft = 750,
                });

            modelBuilder.Entity<Rooms>().HasData(
                new Rooms
                {
                    RoomId = 101,
                    Villa_Id = 1,
                    VillaName = "Royal Villa",
                    SpecificDetails = "Ocean view, private balcony"
                },
                new Rooms
                {
                    RoomId = 102,
                    Villa_Id = 1,
                    VillaName = "Royal Villa",
                    SpecificDetails = "Ground floor, garden access"
                },
                new Rooms
                {
                    RoomId = 201,
                    Villa_Id = 2,
                    VillaName = "Beachfront Villa",
                    SpecificDetails = "Direct beach access"
                },
                new Rooms
                {
                    RoomId = 202,
                    Villa_Id = 2,
                    VillaName = "Beachfront Villa",
                    SpecificDetails = "Upper floor, sea view"
                },
                new Rooms
                {
                    RoomId = 301,
                    Villa_Id = 3,
                    VillaName = "Luxury Pool Villa",
                    SpecificDetails = "Private pool, king bed"
                },
                new Rooms
                {
                    RoomId = 302,
                    Villa_Id = 3,
                    VillaName = "Luxury Pool Villa",
                    SpecificDetails = "Jacuzzi, garden view"
                }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                   warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}
