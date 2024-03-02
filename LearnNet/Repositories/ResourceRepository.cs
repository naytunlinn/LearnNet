using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class ResourceRepository : IRepository<ResourceEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ResourceRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(ResourceEntity entity)
        {
            _applicationDbContext.Resources.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var resourceEntity = await _applicationDbContext.Resources.FindAsync(Id);
                if (resourceEntity != null)
                {
                    _applicationDbContext.Resources.Remove(resourceEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<ResourceEntity>> GetAll()
        {
            return await _applicationDbContext.Resources.ToListAsync();
        }

        public async Task<ResourceEntity> GetById(string Id)
        {
            var resource = await _applicationDbContext.Resources.FirstOrDefaultAsync(m => m.ResourceId == Id);
            if (resource == null)
            {
                throw new Exception("No Resource Data To Show");
            }
            return resource;
        }

        public async Task Update(ResourceEntity entity)
        {
            _applicationDbContext.Resources.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}