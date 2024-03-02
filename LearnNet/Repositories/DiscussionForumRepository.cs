using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class DiscussionForumRepository : IRepository<DiscussionForumEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DiscussionForumRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(DiscussionForumEntity entity)
        {
            _applicationDbContext.DiscussionForums.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var discussionforumEntity = await _applicationDbContext.DiscussionForums.FindAsync(Id);
                if (discussionforumEntity != null)
                {
                    _applicationDbContext.DiscussionForums.Remove(discussionforumEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<DiscussionForumEntity>> GetAll()
        {
            return await _applicationDbContext.DiscussionForums.ToListAsync();
        }

        public async Task<DiscussionForumEntity> GetById(string Id)
        {
            var discussionforum = await _applicationDbContext.DiscussionForums.FirstOrDefaultAsync(m => m.DiscussionForumId == Id);
            if (discussionforum == null)
            {
                throw new Exception("No DiscussionForum Data To Show");
            }
            return discussionforum;
        }

        public async Task Update(DiscussionForumEntity entity)
        {
            _applicationDbContext.DiscussionForums.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}