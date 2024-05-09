using Nghia.API.Data;
using Nghia.API.Models.Domain;

namespace Nghia.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly MyDbContext dbContext;

        public SQLWalkRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
    }
}
