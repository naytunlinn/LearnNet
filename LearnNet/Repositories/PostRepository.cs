using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class PostRepository : IRepository<PostEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(PostEntity entity)
        {
            _applicationDbContext.Posts.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var postEntity = await _applicationDbContext.Posts.FindAsync(Id);
                if (postEntity != null)
                {
                    _applicationDbContext.Posts.Remove(postEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<PostEntity>> GetAll()
        {
            return await _applicationDbContext.Posts.ToListAsync();
        }

        public async Task<PostEntity> GetById(string Id)
        {
            var post = await _applicationDbContext.Posts.FirstOrDefaultAsync(m => m.PostId == Id);
            if (post == null)
            {
                throw new Exception("No Post Data To Show");
            }
            return post;
        }

        public async Task Update(PostEntity entity)
        {
            _applicationDbContext.Posts.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}