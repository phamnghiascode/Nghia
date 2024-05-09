using Microsoft.EntityFrameworkCore;
using Nghia.API.Data;
using Nghia.API.Models.Domain;

namespace Nghia.API.Repositories
{

    public class SQLRegionRepository : IRegionRepository
    {
        private readonly MyDbContext dbContext;

        public SQLRegionRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FindAsync(id);
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            //find region
            var existRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existRegion == null)
            {
                return null;
            }
            existRegion.Code = region.Code;
            existRegion.Name = region.Name;
            existRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            //find
            var existRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(existRegion == null) return null;
            dbContext.Remove(existRegion);
            await dbContext.SaveChangesAsync();
            return existRegion;
        }
    }
}
