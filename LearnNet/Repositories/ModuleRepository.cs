using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class ModuleRepository : IRepository<ModuleEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ModuleRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(ModuleEntity entity)
        {
            _applicationDbContext.Modules.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var moduleEntity = await _applicationDbContext.Modules.FindAsync(Id);
                if (moduleEntity != null)
                {
                    _applicationDbContext.Modules.Remove(moduleEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<ModuleEntity>> GetAll()
        {
            return await _applicationDbContext.Modules.ToListAsync();
        }

        public async Task<ModuleEntity> GetById(string Id)
        {
            var module = await _applicationDbContext.Modules.FirstOrDefaultAsync(m => m.ModuleId == Id);
            if (module == null)
            {
                throw new Exception("No Module Data To Show");
            }
            return module;
        }

        public async Task Update(ModuleEntity entity)
        {
            _applicationDbContext.Modules.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}