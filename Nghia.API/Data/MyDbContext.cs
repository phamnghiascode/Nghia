using Microsoft.EntityFrameworkCore;
using Nghia.API.Models.Domain;

namespace Nghia.API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficuties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("ce6a68d1-b490-4d38-a162-21ce3c371bfa"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f5a9b531-a099-493a-a05a-81c95627adbc"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("261f60b6-efa7-426d-8ea4-7b34cf9beba1"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficuties);


            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("3a5d1dd2-abc5-412b-9e3d-c1b2648a228f"),
                    Name = "Ha Noi",
                    Code = "HN",
                    RegionImageUrl = ""
                },
                new Region
                {
                    Id = Guid.Parse("22715dff-abad-4263-837a-9e97d80fa86d"),
                    Name = "Sai Gon",
                    Code = "SG",
                    RegionImageUrl = ""
                },
                 new Region
                 {
                     Id = Guid.Parse("bc562c11-d7b2-478b-a75d-56a8da71b85a"),
                     Name = "Da Nang",
                     Code = "DN",
                     RegionImageUrl = ""
                 },
                 new Region
                 {
                     Id = Guid.Parse("76675766-473f-4d1d-aba3-e4673f805d0c"),
                     Name = "Ninh Binh",
                     Code = "NB",
                     RegionImageUrl = ""
                 }
            };
            modelBuilder.Entity<Region>().HasData(regions);
       
        }
    }
}
