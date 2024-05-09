using Nghia.API.Models.Domain;

namespace Nghia.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
    }
}
